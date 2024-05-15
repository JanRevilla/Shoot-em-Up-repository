using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public enum GameState
{
    Playing,
    MainMenu
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public GameObject mainMenuUI;
    public GameObject gameUI;

    private GameState currentState;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

        switch (currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1;
                mainMenuUI.SetActive(false);
                gameUI.SetActive(true);
                break;
            case GameState.MainMenu:
                Time.timeScale = 1;
                mainMenuUI.SetActive(true);
                gameUI.SetActive(false);
                break;
        }

    }

    public void OnPlay()
    {
        ChangeState(GameState.Playing);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

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