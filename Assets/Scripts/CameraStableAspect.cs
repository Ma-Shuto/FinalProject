//********************************************************************************
// 全解像度で完全同じ画面を再現 ※Portrait
//********************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.Net.NetworkInformation;
using System.IO;

using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//================================================================================

[ExecuteInEditMode()]
[RequireComponent(typeof(Camera))]
public class CameraStableAspect : MonoBehaviour
{
    [SerializeField]
    Camera refCamera;

    [SerializeField]
    int defWidth = 720;

    [SerializeField]
    int defHeight = 1280;

    [SerializeField]
    float defScale = 6.4f;

    int m_width = -1;
    int m_height = -1;

    void Awake() {
        if( refCamera == null) {
            refCamera = GetComponent<Camera>();
        }
        UpdateCamera();
    }

    private void Update() {
        UpdateCameraWithCheck();
    }

    void UpdateCameraWithCheck() {
        if( m_width == Screen.width && m_height == Screen.height) {
            return;
        }
        UpdateCamera();
    }

    void UpdateCamera()  {
        float screen_w = (float)Screen.width;
        float screen_h = (float)Screen.height;
        float target_w = (float)defWidth;
        float target_h = (float)defHeight;

        //アスペクト比
        float aspect =  screen_w / screen_h;        
        float targetAcpect = target_w / target_h;
        float orthographicSize = (target_h / 2.0f / 100.0f);

        //縦に長い or 横に長い
        if (aspect < targetAcpect) {
            float bgScale_w = target_w / screen_w;
            float camHeight = target_h / (screen_h * bgScale_w);
            refCamera.rect = new Rect( 0.0f, (1.0f - camHeight)*0.5f, 1.0f, camHeight);
        } else {
            // カメラのorthographicSizeを横の長さに合わせて設定しなおす
            float bgScale = aspect / targetAcpect;
            orthographicSize *= bgScale;

            float bgScale_h = target_h / screen_h;
            float camWidth = target_w / (screen_w * bgScale_h);
            refCamera.rect = new Rect( (1.0f - camWidth)*0.5f, 0.0f, camWidth, 1.0f);
        }

 		// スクリーン向き ※Portrait
		if( Screen.width > Screen.height) {
			// 横画面
			refCamera.orthographicSize = defScale;
		} else {
			if( Screen.height > Screen.width) {
				// 縦画面
				refCamera.orthographicSize = orthographicSize;
			} else {
				// デフォルト
				refCamera.orthographicSize = defScale;
			}
		}

        m_width = Screen.width;
        m_height = Screen.height;
    }
}
