using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private GameObject startbutton;

    private GameObject startText;

    private bool tempcheck = true;

    // Start is called before the first frame update
    void Start()
    {
        startbutton = GameObject.Find("PlayButton");
        startText = GameObject.Find("PlayText");
        
    }

    // Update is called once per frame
    void Update()
    {



    }


   public void GameCont()    
    {
        if (tempcheck) {
            startbutton.transform.position += new Vector3(0, 50, 0);
            tempcheck = false;
                }
        startText.GetComponent<Text>().text = "もういちどする？";
    }

    public void  OnClickButton()
    {
        SceneManager.LoadScene("FallingBlock");
        startbutton.transform.position += new Vector3(0, -50, 0);
        tempcheck = true;
    }

}
