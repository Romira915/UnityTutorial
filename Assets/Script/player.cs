using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Collider2D collider2D;
    private SpriteRenderer sprite;
    public Slider slider;
    public saw saw;
    public float speed = 10f;
    public float jump = 5f;
    private bool is_jump = true;
    private bool is_second_jump = true;
    public int HP = 3;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        slider = GameObject.Find("HPbar").GetComponent<Slider>(); // HPbarのコンポーネントを取得する
    }

    // Update is called once per frame
    void Update()
    {
        // 自分の位置を変数posに格納
        var pos = transform.position;

        // "Horizontal"設定されているボタンが押されたら向きに応じて-1～1を返すそうでなければ0を返す．
        // deltaTimeは1つ前のフレームから現在のフレームに更新するまでにかかった時間．これによりフレームレートによって移動速度が変わるのを防ぐ．
        var axis = Input.GetAxis("Horizontal");
        pos.x += axis * speed * Time.deltaTime;

        // 左に移動する時はレンダリング画像を反転させる．
        if (axis < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        // 最後に変更したposで自分の位置を更新．
        transform.position = pos;

        // ジャンプに指定したボタンが押下された時 かつ ジャンプ中ではない時
        if (Input.GetButtonDown("Jump") && !is_jump)
        {
            var v = rigidbody2D.velocity; // velocityを一時変数を格納
            v.y += jump; // 「ジャンプ力」だけ速度を加える
            rigidbody2D.velocity = v; // 変更したvをvelocityに代入する
            is_jump = true; // ジャンプ中にする
        }
        else if (Input.GetButtonDown("Jump") && !is_second_jump) // 二段ジャンプ用
        {
            var v = rigidbody2D.velocity;
            v.y += jump;
            rigidbody2D.velocity = v;
            is_second_jump = true;
        }

        slider.value = HP;

        if (Input.GetButtonDown("Attack"))
        {
            GameObject.Instantiate(saw.gameObject, transform.position, transform.rotation);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // 着地した時
        if (collision.gameObject.tag == "floor")
        {
            is_jump = false;
            is_second_jump = false;
        }

        // 敵に当たった時
        if (collision.gameObject.tag == "enemy")
        {
            HP -= 1;
        }
    }

}
