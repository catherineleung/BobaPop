using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PlayerInteraction : MonoBehaviour
{

    public GameObject[] charList;

    void Awake()
    {
        charList = GameObject.FindGameObjectsWithTag("bobacharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("You are blocking a boba");
            }
        }
    }
}
