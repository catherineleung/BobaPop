using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Gameplay.score = 0;
        Exit.scoreNum = 0;
        PauseMenu.scoreNum = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
