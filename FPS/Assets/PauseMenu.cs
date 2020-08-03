using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenuUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (GamePaused)
            {
                Resume();
            }else
            {
                Pause();
            } 
        }

        void Resume()
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;

        }
        
        void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }

       
    } 
    public void LoadMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    public void QuitGame()
        {
            Application.Quit();
            Debug.Log("QUIT!");
        }
}
