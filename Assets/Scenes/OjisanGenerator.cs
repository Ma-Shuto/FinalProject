using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjisanGenerator : MonoBehaviour
{
    public GameObject[] Ojisan;
    // Start is called before the first frame update
    void Start()
    {
        NewOjisan();
    }

    public void NewOjisan()
    {
        Instantiate(Ojisan[Random.Range(0, Ojisan.Length)], transform.position, Quaternion.identity);
    }
}