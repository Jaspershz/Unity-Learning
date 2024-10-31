using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject GameOverMenu;
    private bool isPaused = false;
    private bool inMainMenu = false;

    // Update is called once per frame
    
    void Start(){
        if(PauseMenu == null && GameOverMenu == null){
            inMainMenu = true;
        }
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inMainMenu){
            if(isPaused)
                Resume();
            else
                Pause();
        }
    }

    public bool getIsPaused(){
        return isPaused;
    }

    public void Resume(){
        isPaused = false;
        PauseMenu.SetActive(isPaused);
        Time.timeScale = 1f;
    }

    public void Pause(){
        isPaused = true;
        PauseMenu.SetActive(isPaused);
        Time.timeScale = 0f;
    }

    public void GameOver(){
        isPaused = true;
        GameOverMenu.SetActive(true);
    }

    public void StartGame(){
        inMainMenu = false;
        SceneManager.LoadScene("Gameplay");
    }

    public void toMainMenu(){
        inMainMenu = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart(){
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
