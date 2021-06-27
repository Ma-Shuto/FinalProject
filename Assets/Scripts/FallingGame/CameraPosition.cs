using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    public float positionY;

    // Start is called before the first frame update
    void Start()
    {
        positionY= this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        positionY = this.transform.position.y;
    }

    public float getcameraPosition()
    {
        return positionY;
    }

    public void moveCamera()
    {
       this.transform.position += new Vector3(0, 3, 0);
    }
}
