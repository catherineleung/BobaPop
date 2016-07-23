using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour
{

    // holds different GameObjects
    public GameObject[] charList;

    // max numbers of characters
    public int maxCharCount = 5;

    private GameObject selected = null;

    // list to keep all bobas in combo
    private ArrayList comboList;

    // keeps all created bobas
    private GameObject bobaPlace;


    // Use this for initialization
    void Start()
    {

        comboList = new ArrayList();

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
        for (int i = 0; i < 10; i++)
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


    /********* helper for conditions for combos *********/

    // sets the last boba of combo as selected
    void SetLastBobaAsSelected(bool selected)
    {
        BobaCharacter bobachar = GetLastBoba();
        if (bobachar != null)
        {
            bobachar.SetSelected(selected);
        }
    }

    // gets last boba of the combo
    BobaCharacter GetLastBoba()
    {
        if (comboList.Count > 0)
        {
            return comboList[comboList.Count - 1] as BobaCharacter;
        }

        else
        {
            return null;
        }
    }

    // gets all bobas allowed in combo that are around the currently selected boba and highlights them
    void HighlightAllowedBobas(BobaCharacter bobachar)
    {
        foreach (BobaCharacter b in bobaPlace.GetComponentsInChildren<BobaCharacter>())
        {
            if (b.Check(b) && !comboList.Contains(b))
            {
                b.SetHighlight(true);
                HighlightAllowedBobas(b);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // touch began
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(p, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "bobacharacter")
                {
                    BobaCharacter bobachar = hit.collider.GetComponent<BobaCharacter>();
                    if (bobachar.Check(bobachar))
                    {
                        comboList.Add(bobachar);
                        bobachar.SetSelected(true);
                    }

                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // touch ended
            // check if combo is more than 2... if it is...
            if (comboList.Count > 2)
            {
                // go through every boba in combo and delete them
                foreach (BobaCharacter bobachar in comboList)
                {
                    Destroy(bobachar.gameObject);
                }
            }
            else
            {
                // combo must be less than 2 bobas so set last boba as unselected
                SetLastBobaAsSelected(false);
            }
            // clear all bobas in list
            comboList.Clear();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(p, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "bobacharacter")
                {
                    BobaCharacter bobachar = hit.collider.GetComponent<BobaCharacter>();

                    // if pet is not already inside combo
                    if (!comboList.Contains(bobachar))
                    {
                        // is it allowed to be part of combo?
                        if (GetLastBoba().Check(bobachar))
                        {
                            // make last boba in combo unselected
                            SetLastBobaAsSelected(false);

                            // add it to the combo
                            comboList.Add(bobachar);

                            // make it selected
                            bobachar.SetSelected(true);
                        }
                    }

                    else
                    {
                        // boba is inside combo
                        int index = comboList.LastIndexOf(bobachar);

                        if (index == comboList.Count - 2)
                        {
                            SetLastBobaAsSelected(false);
                            comboList.RemoveAt(comboList.Count - 1);
                            SetLastBobaAsSelected(true);
                        }
                    }

                    //if (selected != hit.collider.gameObject)
                    //{
                    //    // boba character selected
                    //    if (selected != null)
                    //    {
                    //        // not selected
                    //        selected.GetComponent<Animator>().SetBool("selected", false);
                    //    }
                    //    hit.collider.GetComponent<Animator>().SetBool("selected", true);
                    //    selected = hit.collider.gameObject;
                    //}
                }
            }
        }

        foreach (BobaCharacter bobachar in bobaPlace.GetComponentsInChildren<BobaCharacter>())
        {
            bobachar.SetHighlight(false);
        }

        if (comboList.Count > 0)
        {
            HighlightAllowedBobas(GetLastBoba());
        }
    }

}
