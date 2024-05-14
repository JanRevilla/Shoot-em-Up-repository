using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public enum GameState
{
    Playing,
    // Paused,
    MainMenu
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    // public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    // public GameObject gameUI; // asigna en el inspector (los 3)

    private GameState currentState;



    private void Awake()
    {
       /*
       if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
       else
        {
            Destroy(gameObject);
        }

        */

    }

    private void Start()
    {
        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        HandleStateChange();
    }
    
    private void HandleStateChange()
    {
        /*
        switch (currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1;
                // pauseMenuUI.SetActive(false);
                mainMenuUI.SetActive(false);
                gameUI.SetActive(true);
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                // pauseMenuUI.SetActive(true);
                mainMenuUI.SetActive(false);
                gameUI.SetActive(false);
                break; 
            case GameState.MainMenu:
                Time.timeScale = 1;
                // pauseMenuUI.SetActive(false);
                mainMenuUI.SetActive(true);
                gameUI.SetActive(false);
                break;
        }
        */
    }
    
    // Métodos para los botones del UI
    public void OnPlay()
    {
        // Cambiar al estado Playing
        ChangeState(GameState.Playing);

        // Cargar la escena del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /*
    public void OnPause()
    {
        ChangeState(GameState.Paused);
    }
    */
    public void OnMainMenu()
    {
        ChangeState(GameState.MainMenu);
    }

    public void OnExit()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

}
