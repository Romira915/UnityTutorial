using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class saw : MonoBehaviour
{
    public float speed = 3f;
    public int attack = 1;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (!renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
