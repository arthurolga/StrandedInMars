using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    
    public Text TimeText;

    private float TimeCounter;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        TimeText.text = string.Format("TIME: {0} s", TimeCounter);
    }

    public void SetTimeScore(){
        PlayerPrefs.SetFloat("TimeCounter", TimeCounter);
    }
}
