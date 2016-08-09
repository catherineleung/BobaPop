using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{

    // holds different GameObjects
    public GameObject[] charList;

	public GameObject topCollider = GameObject.FindGameObjectWithTag ("boundary");

    // max numbers of characters
    public int maxCharCount = 5;

    private GameObject selected = null;

    // list to keep all bobas in combo
    private ArrayList comboList;

    // keeps all created bobas
    private GameObject bobaPlace;

    // Text used for interacting with the score
    public Text scoreDisplay;

    // Actually keeping track of score; initial score is 0
    public static int score = 0;

    //check to see if the bobas land outside the cup. True if there is a boba outside, false otherwise
	public bool outside = false;

    //y-position of the upper boundary of the cup
    public static float boundaryY = 4;

    //x-position of the upper boundary of the cup
    public static float boundaryX;// = GameObject.FindGameObjectWithTag("boundary").transform.position.x;

    //width of the upper boundary of the cup

    // Use this for initialization
    void Start()
    {
        bobaPlace = new GameObject("BobaPlace");

        comboList = new ArrayList();



		topCollider.SetActive (false);

        for (int i = 0; i < maxCharCount; i++)
        {
            // creates a new instance of prefab object obtained from charList array
            // Random.Range gets random x value from -2.6f to 2.6f
            GameObject instance = Instantiate(charList[Random.Range(0, charList.Length)], new Vector3(Random.Range(-2.6f, 2.6f), 7.0f, -1.0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(bobaPlace.transform);
        }

        
        InvokeRepeating("addBobaHelper", 0, 6F);
        InvokeRepeating("IsBobaOutside", 2, 5F);

    }


    //Helper for dropping new boba during gameplay
    void addBobaHelper()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject instance = Instantiate(charList[Random.Range(0, charList.Length)], new Vector3(Random.Range(-2.6f, 2.6f), 7.0f, -1.0f), Quaternion.identity) as GameObject;
        }

    }

    void setOutsideFalse()
    {
        outside = false;
    }

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
            if (b.Check(bobachar) && !comboList.Contains(b))
            {
                b.SetHighlight(true);
                HighlightAllowedBobas(b);
            }
        }
    }
    
    //sets variable "outside" to true/false depending on whether this finds that a boba has exceeded cup boundaries
    void IsBobaOutside()
    {
        //iterates over all boba to see if it had touched the top
        GameObject[] bobas = charList;

        for (int i = 0; i < bobas.Length; i++)
        {
            //if it touches anywhere between -4 and 4 on the x-axis, then return true
            float bobaY = bobas[i].transform.position.y;
            if (bobaY > boundaryY)
            {
                outside = true;
                Debug.Log("HEYYYYYYYYYYYYYYYYYYY!!!!!!!!!!!");
            
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
                    //multiply the amount in combo * 100

                    score += (comboList.Count * 100);
                    if (bobachar.gameObject != null)
                    {
                        Destroy(bobachar.gameObject);
                    }

                    scoreDisplay.text = "" + score;

                    // updates score for exit menu and pause menu
                    Exit.scoreNum = score;
                    PauseMenu.scoreNum = score;
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

        foreach (BobaCharacter b in bobaPlace.GetComponentsInChildren<BobaCharacter>())
        {
            b.SetHighlight(false);
        }


        if (comboList.Count > 0)
        {
            HighlightAllowedBobas(GetLastBoba());
        }

        

        

        /*if (outside)
        {
            SceneManager.LoadScene(2);
        }*/

    }

}
