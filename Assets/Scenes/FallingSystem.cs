using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingSystem : MonoBehaviour
{
    public float previousTime;
    // Ojisanの落ちる時間
    public float fallTime = 0.1f;

    
    // Ojisan回転
    public Vector3 rotationPoint;

    //ループ停止用緊急処置
    public int num = 0;
    void Update()
    {
        OjisanMovememt();
    }

    private void OjisanMovememt()
    {
        // 左矢印キーで左に動く
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);


        }
        // 右矢印キーで右に動く
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        // 自動で下に移動させつつ、下矢印キーでも移動する
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - previousTime >= fallTime)
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Ojisanを上矢印キーを押して回転させる
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        num += 1;
        //新しいおじさんを作る
        this.enabled = false;
        FindObjectOfType<OjisanGenerator>().NewOjisan();

            if (num > 10)
        {
            UnityEngine.Application.Quit();
        }
    }
}