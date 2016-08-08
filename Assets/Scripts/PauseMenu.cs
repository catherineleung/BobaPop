using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //to determine if the game is paused or not
    public bool isPaused;

    // score text
    public Text currentScore;
    public static int scoreNum;

    //the actual pause menu graphic
    public GameObject pauseMenuCanvas;

    void Start()
    {
        currentScore.text = scoreNum.ToString();
    }

    // Update is called once per frame
    void Update() {
        if (currentScore.text != scoreNum.ToString())
        {
            currentScore.text = scoreNum.ToString();
        }
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

    public void Restart()
    {
        SceneManager.LoadScene(1);
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

}
