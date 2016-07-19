using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

    // holds different GameObjects
    public GameObject[] charList;

    // max numbers of characters
    public int maxCharCount = 5;

    private GameObject selected = null;


    // Use this for initialization
    void Start () {
        for (int i = 0; i < maxCharCount; i++)
        {
            // creates a new instance of prefab object obtained from charList array
            // Random.Range gets random x value from -2.6f to 2.6f
            GameObject instance = Instantiate(charList[Random.Range(0, charList.Length)], new Vector3(Random.Range(-2.6f, 2.6f), 7.0f, -1.0f), Quaternion.identity) as GameObject;

        }

        InvokeRepeating("addBobaHelper", 0, 6F);

    }

    //Helper for dropping new boba during gameplay
    void addBobaHelper()
    {
        for (int i = 0; i<10; i++)
        {
            GameObject instance = Instantiate(charList[Random.Range(0, charList.Length)], new Vector3(Random.Range(-2.6f, 2.6f), 7.0f, -1.0f), Quaternion.identity) as GameObject;
        }
        
    }

    //For actually dropping new boba

    /*IEnumerator addBoba()
    {
        //TODO: Fix later to stop dropping after game ends
        while (true)
        {
            InvokeRepeating("addBobaHelper", 5, 5F);
        }
    }*/
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            // simulate touch began
        }

        if (Input.GetMouseButtonUp(0))
        {
            // simulate touch ended
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(p, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "bobacharacter")
                {
                    if (selected != hit.collider.gameObject)
                    {
                        // boba character selected
                        if (selected != null)
                        {
                            // not selected
                            selected.GetComponent<Animator>().SetBool("selected", false);
                        }
                        hit.collider.GetComponent<Animator>().SetBool("selected", true);
                        selected = hit.collider.gameObject;
                    }
                }
            }
        }
    }

}
