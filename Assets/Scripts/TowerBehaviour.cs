using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerBehaviour : MonoBehaviour
{
    public float GameLifes = 3;
    public TextMeshProUGUI text;
    TextScript textScript;
    bool is2lifes, is1life;

    public void Start()
    {
        textScript = text.GetComponent<TextScript>();
        is2lifes = true;
        is1life = true;
    }

    public void Update()
    {
        if (GameLifes == 2 && is2lifes)
        {
            textScript.TextRemains = 0;
            textScript.textValue = "2 hits remaining";
            textScript.newText = true;
            is2lifes = false;
        }
        if (GameLifes == 1 && is1life)
        {
            textScript.newText = true;
            textScript.TextRemains = 0;
            textScript.textValue = "1 hit remaining";
            is1life = false;
        }
        if (GameLifes == 0)
        {
            PointSystem.points = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            GameStateManager.Instance.ChangeState(GameState.MainMenu);
        }


    }
}
