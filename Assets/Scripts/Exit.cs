using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Exit : MonoBehaviour {

    public static int scoreNum;
    public Text score;

    void Start()
    {
        score.text = scoreNum.ToString();
    }

	void OnMouseDown()
    {
        transform.localScale *= 0.9F;
    }

    void OnMouseUp()
    {
        Application.Quit();
    }
}

