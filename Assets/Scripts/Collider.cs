using UnityEngine;
using System.Collections;

public class Collider : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCup()
    {
        foreach (Transform child in this.transform)
        {

            child.gameObject.SetActive(true);
            
        }
    }
}