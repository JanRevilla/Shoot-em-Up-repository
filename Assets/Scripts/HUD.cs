using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] Lives;
   
    public void DisableHeart(int index)
    {
        Lives[index].SetActive(false);

    }
    public void EnableHeart(int index)
    {
        Lives[index].SetActive(true);
    }
}
