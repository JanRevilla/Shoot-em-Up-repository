using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    MainMenu,
    Paused // Añadir el estado de pausa
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public GameObject mainMenuUI;
    public GameObject gameUI;
    public GameObject pauseMenuUI; // Añadir referencia al menú de pausa
    public GameObject pauseButtonUI;

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
        currentState = GameState.MainMenu;
        Debug.Log("Start called. Current state: " + currentState);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1;
                mainMenuUI.SetActive(false);
                gameUI.SetActive(true);
                pauseMenuUI.SetActive(false);
                pauseButtonUI.SetActive(true); // Activar el botón de pausa
                break;
            case GameState.MainMenu:
                Time.timeScale = 1;
                mainMenuUI.SetActive(true);
                gameUI.SetActive(false);
                pauseMenuUI.SetActive(false);
                pauseButtonUI.SetActive(false); // Asegúrate de que el botón de pausa esté desactivado
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                pauseMenuUI.SetActive(true);
                gameUI.SetActive(false);
                mainMenuUI.SetActive(false);
                pauseButtonUI.SetActive(false); // Asegúrate de que el botón de pausa esté desactivado
                break;
        }
    }

    public void OnPlay()
    {
        ChangeState(GameState.Playing);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // pauseButtonUI.SetActive(true);
        Debug.Log("OnPlay called. Current state: " + currentState);
    }

    public void OnMainMenu()
    {
        ChangeState(GameState.MainMenu);
        Debug.Log("OnMainMenu called. Current state: " + currentState);
    }

    public void OnPause()
    {
        // pauseButtonUI.SetActive(false);
        ChangeState(GameState.Paused);
        Debug.Log("OnPause called. Current state: " + currentState);
    }

    public void OnExit()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void OnResume()
    {
        // pauseButtonUI.SetActive(true);
        if (currentState == GameState.Paused)
        {
            ChangeState(GameState.Playing);
        }
        Debug.Log("OnResume called. Current state: " + currentState);

    }

    public void OnRestart()
    {
        // pauseButtonUI.SetActive(true);
        PointSystem.points = 0;
        // Reiniciar el nivel actual
        ChangeState(GameState.Playing);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("OnRestart called. Current state: " + currentState);
    }
}
