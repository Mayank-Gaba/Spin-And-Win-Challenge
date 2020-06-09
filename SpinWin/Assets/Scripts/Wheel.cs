using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    int rand;
    private bool spinAllowed;
    private float timeInterval;
    private float totalAngle;
    private float finalAngle;

    void Start()
    {   
        spinAllowed = true;
        totalAngle = 360/12;
    }
    void Update()
    {
        if(Input.GetMouseButton(0) && spinAllowed)
            StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        spinAllowed = false;
        rand = Random.Range(20,30);
        timeInterval = 0.1f;

        for(int i=0;i<rand;i++)
        {
                transform.Rotate(0,0,totalAngle/2);
                 if (i > Mathf.RoundToInt (rand * 0.5f))timeInterval = 0.2f;
                 if (i > Mathf.RoundToInt (rand * 0.85f))timeInterval = 0.4f;
                 yield return new WaitForSeconds (timeInterval);
        }

        if(Mathf.RoundToInt (transform.eulerAngles.z) % 45 != 0)transform.Rotate (0, 0, 22.5f);
        finalAngle = Mathf.RoundToInt (transform.eulerAngles.z);
        
        spinAllowed = true;
    }
}
