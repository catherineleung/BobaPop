using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //to determine if the game is paused or not
    public bool isPaused;

    //the actual pause menu graphic
    public GameObject pauseMenuCanvas;

	// Update is called once per frame
	void Update () {
	}

    public void Pause()
    {
        //isPaused = !isPaused;

        //if (isPaused)
        //{
            Time.timeScale = 0;
            pauseMenuCanvas.SetActive(true);
        /*}
        else {
            Time.timeScale = 1;
            pauseMenuCanvas.SetActive(false);
        }*/

    }

    public void Resume()
    {
        //isPaused = !isPaused;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }


}
