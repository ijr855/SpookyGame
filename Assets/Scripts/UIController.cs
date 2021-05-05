using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class UIController : MonoBehaviour
{
    RigidbodyFirstPersonController firstPersonController;

    GameObject quitButton;
    GameObject resumeButton;

    GameObject newGameButton;
    GameObject gameOverQuitButton;

    GameObject gameOverText;

    public bool isPaused = false;
    public bool pauseDisabled = false;
    public bool isDeadMenuEnabled = false;

    private void Awake()
    {
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>();

        quitButton = GameObject.FindGameObjectWithTag("QuitButton");
        resumeButton = GameObject.FindGameObjectWithTag("ResumeButton");

        newGameButton = GameObject.FindGameObjectWithTag("NewGameButton");
        gameOverQuitButton = GameObject.FindGameObjectWithTag("GameOverQuitButton");

        gameOverText = GameObject.FindGameObjectWithTag("GameOverText");

        GameObject.FindGameObjectWithTag("ResumeButton").SetActive(false);
        GameObject.FindGameObjectWithTag("QuitButton").SetActive(false);

        GameObject.FindGameObjectWithTag("NewGameButton").SetActive(false);
        GameObject.FindGameObjectWithTag("GameOverQuitButton").SetActive(false);

        GameObject.FindGameObjectWithTag("GameOverText").SetActive(false);
    }

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("escape")) && !isPaused && !pauseDisabled)
        {
            PauseGame();
        }
        //else if (Input.GetKeyDown(KeyCode.Q) && isPaused)
        //{
        //    QuitGame();
        //}
        else if (Event.current.Equals(Event.KeyboardEvent("escape")) && isPaused && !pauseDisabled)
        {
            ResumeGame();
        }
        //else if (Input.GetKeyDown(KeyCode.Q) && isDeadMenuEnabled)
        //{
        //    QuitGame();
        //}
        //else if(Input.GetKeyDown(KeyCode.N) && isDeadMenuEnabled)
        //{
        //    NewGame();
        //}

        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>().isDead)
        {
            GameOverMenu();
        }
    }

    public void PauseGame()
    {
        firstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        resumeButton.SetActive(true);
        quitButton.SetActive(true);

        Time.timeScale = 0;

        isPaused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        resumeButton.SetActive(false);
        quitButton.SetActive(false);

        Time.timeScale = 1;

        isPaused = false;

        firstPersonController.enabled = true;
    }

    public void GameOverMenu()
    {
        firstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isDeadMenuEnabled = true;

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>().isDead = true;

        pauseDisabled = true;

        gameOverText.SetActive(true);
        newGameButton.SetActive(true);
        gameOverQuitButton.SetActive(true);

        Time.timeScale = 0;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);

        firstPersonController.enabled = true;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
