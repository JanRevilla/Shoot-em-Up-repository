using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] Lives;
    private HealthComponent healthComponent;

    private void Start()
    {
        healthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>();
        healthComponent.OnHitReceived += DisableHeart;
    }
    public void DisableHeart()
    {
        for (int i = Lives.Length - 1; i >= 0; i--)
        {
            if (Lives[i].activeSelf)
            {
                Lives[i].SetActive(false);
                break;
            }
        }
    }

    /*
    public void EnableHeart(int index)
    {
        Lives[index].SetActive(true);
    }
    */
}