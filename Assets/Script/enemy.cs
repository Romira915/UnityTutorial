using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float speed = 1f;
    private int HP = 3;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (!sprite.isVisible)
        {
            Destroy(gameObject);
        }
    }

    // 自分を動かす
    void Move()
    {
        sprite.flipX = true;

        var pos = transform.position;
        pos.x -= speed * Time.deltaTime;

        transform.position = pos;
    }

    // ダメージを受ける
    void Damage(int attack)
    {
        HP -= attack;

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // 画像を点滅させる
    IEnumerator Flashing()
    {
        var color = sprite.color;
        for (int i = 0; i < 2; i++)
        {
            color.a = 0;
            sprite.color = color;
            yield return new WaitForSeconds(0.1f);
            color.a = 255;
            sprite.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // sawに当たった時
        if (collider.gameObject.tag == "saw")
        {
            var saw = collider.gameObject.GetComponent<saw>();
            Damage(saw.attack);
            StartCoroutine("Flashing");
        }
    }
}
