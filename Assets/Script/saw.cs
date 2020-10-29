using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class saw : MonoBehaviour
{
    public float speed = 3f;
    public int attack = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    bool is_onScreen()
    {
        Screen.

        return true;
    }
}
