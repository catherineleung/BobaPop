using UnityEngine;
using System.Collections;

public class Shuffle : MonoBehaviour
{

    public GameObject[] charList;

    public GameObject topCollider;

    public void Start()
    {
        topCollider = GameObject.FindGameObjectWithTag("boundary");
          

    }

    // Use this for initialization
    public void ShuffleBobas()
    {

        charList = GameObject.FindGameObjectsWithTag("bobacharacter");
		Rigidbody2D rb;

        
        

        for (int i = 0; i < charList.Length; i++)
        {
            rb = charList[i].GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-100, 100), 200));

            //Vector3 temp = charList[i].transform.position;
            //int randomIndex = Random.Range(0, charList.Length);
            //charList[i].transform.position = charList[randomIndex].transform.position;
            //charList[randomIndex].transform.position = temp;
        }
    }

    
}
