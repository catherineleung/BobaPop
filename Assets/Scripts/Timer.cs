using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text TimeDisplay;
    public float timeRemains = 60;
	
	// Update is called once per frame
	void Update () {

        if (timeRemains > 0)
        {
            timeRemains -= Time.deltaTime;
            TimeDisplay.text = "" + (int) timeRemains;
        }
        else
        {
            TimeDisplay.text = "" + (int)timeRemains;
        }
        
	}
}
