using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameEnd: MonoBehaviour
{
    private bool isEnd = false;

    private GameObject gameGenerator_End;

    private GameObject playButton;

    //オーディオオブジェクト
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameGenerator_End = GameObject.Find("OjisanGenerator");
        playButton = GameObject.Find("PlayButton");
        audioSource = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
       
        if (isEnd)
        {
            gameGenerator_End.GetComponent<OjisanGenerator>().GameEnd();
            playButton.GetComponent<PlayButton>().GameCont();
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        isEnd = true;

    }

   
}
