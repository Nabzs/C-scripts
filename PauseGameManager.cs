using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
public class PauseGameManager : MonoBehaviour
{

public TextMeshProUGUI LevelText;

public GameObject PauseCanvas;
public KeyCode PauseKey = KeyCode.Tab;


bool isPaused;
private void Update()
{
    LevelText.text = SceneManager.GetActiveScene().name;

    if (Input.GetKeyUp(PauseKey)) 
    
    {
        isPaused = !isPaused;

        if (!isPaused) ResumeGame();
    }


    if(isPaused)
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //disable character

        FindObjectOfType<FirstPersonController>().enabled = false;
    }

    else
    {
        PauseCanvas.SetActive(false);
    }
}

public void ResumeGame()
{
    // unpause game
        isPaused = false;

        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //disable character
        FindObjectOfType<FirstPersonController>().enabled = true;
}
public void QuiteGame()
{
     isPaused = false;

        Time.timeScale = 1;
        AudioListener.pause = false;

        SceneManager.LoadScene("MainMenu");
}

public void RestartLevel()
{
    ResumeGame();
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

}
