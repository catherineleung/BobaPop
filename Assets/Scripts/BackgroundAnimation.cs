using UnityEngine;
using System.Collections;

public class BackgroundAnimation : MonoBehaviour {

    public GameObject[] charList;

    // Use this for initialization
    void Start () {
        InvokeRepeating("FallingBoba", 0, 0.65416546F);
        InvokeRepeating("FallingBoba", 0, 1.33333333F);
        InvokeRepeating("FallingBoba", 0, 2.235265652263F);
        InvokeRepeating("FallingBoba", 0, 3.53315F);
        InvokeRepeating("FallingBoba", 0, 3.7315F);
    }

    void FallingBoba()
    {
        GameObject instance = Instantiate(charList[Random.Range(0, charList.Length)], new Vector3(Random.Range(-2.6f, 2.6f), 7.0f, -1.0f), Quaternion.identity) as GameObject;
    }
	
}
