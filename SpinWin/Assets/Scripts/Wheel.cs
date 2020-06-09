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

    void Start()
    {   
        spinAllowed = true;
        totalAngle = 360/12;
    }
    void Update()
    {
        if(Input.GetKeyDown("space") && spinAllowed)
            StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        spinAllowed = false;
        rand = Random.Range(250,300);
        timeInterval = 0.0001f*2*Time.deltaTime;

        for(int i=0;i<rand;i++)
        {
                transform.Rotate(0,0,totalAngle/2);
                if(i > Mathf.RoundToInt (rand * 0.2f))timeInterval = 0.5f*Time.deltaTime;
                if(i > Mathf.RoundToInt (rand * 0.3f))timeInterval = 1.0f*Time.deltaTime;
                if(i > Mathf.RoundToInt (rand * 0.5f))timeInterval = 1.5f*Time.deltaTime;
                if(i > Mathf.RoundToInt (rand * 0.8f))timeInterval = 2.0f*Time.deltaTime;
                if(i > Mathf.RoundToInt (rand * 0.9f))timeInterval = 2.5f*Time.deltaTime;
                
                yield return new WaitForSeconds (timeInterval);
        }

        if(Mathf.RoundToInt (transform.eulerAngles.z) % 30 != 0)transform.Rotate (0, 0,21f);        
        spinAllowed = true;
    }
}
