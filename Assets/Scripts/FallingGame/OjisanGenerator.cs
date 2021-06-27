using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OjisanGenerator : MonoBehaviour
{

    public GameObject[] Ojisan;

    private bool flag = false;
    private float TimeCounter = 0f;
    private int countObj = 0;
    private GameObject stateText;
    private GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        //一つ目作成
        Instantiate(Ojisan[Random.Range(0, Ojisan.Length)], transform.position, Quaternion.identity);
        stateText = GameObject.Find("GameResultText");
        score = GameObject.Find("Score");

    }

    void Update()
    {
        if (flag)
        {
            if (TimeCounter >1.0f)
            {
                Instantiate(Ojisan[Random.Range(0, Ojisan.Length)], transform.position, Quaternion.identity);
                flag = false;
                countObj += 1;
                this.score.GetComponent<Text>().text = "てのひらに " + countObj + "おじさん";

            }
        }

        TimeCounter += Time.deltaTime;

    }

    public void NewOjisan()
    {
        flag = true;
        TimeCounter = 0f;
    }

    public void GameEnd()
    {

        flag = false;
        this.score.GetComponent<Text>().text = "";
        this.stateText.GetComponent<Text>().text = "おしまい\n"+"さいだい\n"+"おじさんすう\n" + countObj+"おじさん"; 

    }

    public void moveOjisan()
    {

        this.transform.position += new Vector3(0, 5, 0);
    }
}