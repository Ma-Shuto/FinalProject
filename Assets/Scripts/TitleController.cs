using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    void Start()
    {
		// シーン リセット
		SystemDaemon.SceneReset();
    }

    void Update()
    {
        // エンター？
		if( Input.GetKeyDown( KeyCode.Return))
		{
			// シーン ローディング
			LoadingController.Scene = "Game";
			SystemDaemon.LoadScene( "Loading");
		}
    }
}
