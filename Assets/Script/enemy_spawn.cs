using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public enemy Enemy;
    //private float spawn_count = 0;
    public float spawn_span = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        // コルーチンと同様の処理
        //spawn_count += Time.deltaTime;

        //if (spawn_count > spawn_span)
        //{
        //    GameObject.Instantiate(Enemy.gameObject, transform.position, transform.rotation);
        //    spawn_count = 0;
        //}
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject.Instantiate(Enemy.gameObject, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawn_span);
        }
    }
}
