using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class stage : MonoBehaviour
{
    public GameObject stage_obj;
    private Camera main_camera;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj_camera = GameObject.Find("Main Camera");
        main_camera = obj_camera.GetComponent<Camera>();

        float width = stage_obj.GetComponent<SpriteRenderer>().bounds.size.x;
        float worldwidth = getScreenTopRight().x - getScreenBottomLeft().x;

        for (int i = 0; i < worldwidth / width + 1; i++)
        {
            GameObject obj = Instantiate(stage_obj, new Vector3(getScreenBottomLeft().x + i * width, -3, 0), Quaternion.identity) as GameObject;
            obj.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 getScreenBottomLeft()
    {
        // 画面の左上を取得
        Vector3 topLeft = main_camera.ScreenToWorldPoint(Vector3.zero);
        return topLeft;
    }

    private Vector3 getScreenTopRight()
    {
        // 画面の右下を取得
        Vector3 bottomRight = main_camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        return bottomRight;
    }
}
