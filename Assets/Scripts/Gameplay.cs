using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

    // holds different GameObjects
    public GameObject[] charList;

    // max numbers of characters
    public int maxCharCount = 100;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < maxCharCount; i++)
        {
            // creates a new instance of prefab object obtained from charList array
            // Random.Range gets random x value from -2.6f to 2.6f
            GameObject instance = Instantiate(charList[Random.Range(0, charList.Length)], new Vector3(Random.Range(-2.6f, 2.6f), 7.0f, -1.0f), Quaternion.identity) as GameObject;
        }

    }

    //Helper for dropping new boba during gameplay
    void addBobaHelper()
    {
        
    }

    //For actually dropping new boba

    IEnumerator addBoba()
    {
        //TODO: Fix later to stop dropping after game ends
        while (true)
        {
            addBobaHelper();
            yield return new WaitForSeconds(5);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

}
