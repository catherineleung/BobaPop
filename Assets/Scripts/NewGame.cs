using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	void OnMouseDown()
    {
        //This makes the words smaller when we press down on it
        transform.localScale *= 0.9F;
    }

    void OnMouseUp()
    {
        //Application.LoadLevel(1); obsolete
        SceneManager.LoadScene(1);
    }
}
