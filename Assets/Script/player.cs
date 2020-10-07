using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed = 15f;
    public float jump = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 自分の位置を変数posに格納
        var pos = transform.position;

        // "Horizontal"設定されているボタンが押されたら向きに応じて-1～1を返すそうでなければ0を返す．
        // deltaTimeは1つ前のフレームから現在のフレームに更新するまでにかかった時間．これによりフレームレートによって移動速度が変わるのを防ぐ．
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // 最後に変更したposで自分の位置を更新．
        transform.position = pos;

        if (Input.GetAxisRaw("Jump").Equals(1))
        {
            rigidbody2D.AddForce(new Vector2(0, jump));
        }
    }

}
