using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScoreTextScript : MonoBehaviour
{
    private float TimeCounter;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
       text = GetComponent<Text> (); 
       
       TimeCounter =  PlayerPrefs.GetFloat("TimeCounter", TimeCounter);

       text.text = string.Format("TimeScore: {0} s", TimeCounter);
       
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
