using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingSystem : MonoBehaviour
{

    private GameObject cameraObj;
    private float cameraPosition;

    private bool saudioChecker = true;


    //オーディオオブジェクト
    public AudioSource audioSource;

    // Ojisan回転
    public Vector3 rotationPoint;

    //動作フラグ
    private bool movement = true;

    //呼び出し
    private GameObject generator;


    //ボタンの判定
    //左ボタン押下の判定
    private bool isLButtonDown = false;
    //右ボタン押下の判定
    private bool isRButtonDown = false;
    //下ボタン押下の判定
    private bool isDButtonDown = false;
    //上ボタン押下の判定
    private bool isUButtonDown = false;


    void Start()
    {
        generator = GameObject.Find("OjisanGenerator");
        cameraObj = GameObject.Find("Main Camera");
        cameraPosition = cameraObj.transform.position.y;
        audioSource = this.GetComponent<AudioSource>();
    }

void Update()
    {
        if (movement)
        {

            OjisanMovememt();
        }

    
    }

    private void OjisanMovememt()
    {
        // 左矢印キーで左に動く
        if (Input.GetKeyDown(KeyCode.LeftArrow) || this.isLButtonDown)
        {
            transform.position += new Vector3(-1, 0, 0);

        }
        // 右矢印キーで右に動く
        else if (Input.GetKeyDown(KeyCode.RightArrow) || this.isRButtonDown) 
        {
            transform.position += new Vector3(1, 0, 0);
        }
        // 自動で下に移動させつつ、下矢印キーでも移動する
        else if (Input.GetKeyDown(KeyCode.DownArrow)||this.isDButtonDown)
        {
            transform.position += new Vector3(0, -1, 0);
          
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || this.isUButtonDown)
        {
            // Ojisanを上矢印キーを押して回転させる
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (saudioChecker)
        {
            audioSource.Play();

            saudioChecker = false;
        }
        


        if (movement)
        {
            cameraPosition = cameraObj.transform.position.y;
           
            generator.GetComponent<OjisanGenerator>().NewOjisan();

            if (cameraPosition-this.transform.position.y < -1)
            {
                cameraObj.GetComponent<CameraPosition>().moveCamera();
                generator.GetComponent<OjisanGenerator>().moveOjisan();

            }
            
            
        }
        movement = false;


    }
   

    //左ボタンを押し続けた場合の処理）
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }

    //下ボタンを押し続けた場合の処理）
    public void GetMyDownButtonDown()
    {
        this.isDButtonDown = true;
    }
    //下ボタンを離した場合の処理
    public void GetMyDownButtonUp()
    {
        this.isDButtonDown = false;
    }

    //上ボタンを押し続けた場合の処理
    public void GetMyUpButtonDown()
    {
        this.isUButtonDown = true;
    }
    //上ボタンを離した場合の処理
    public void GetMyUPButtonUp()
    {
        this.isUButtonDown = false;
    }
}