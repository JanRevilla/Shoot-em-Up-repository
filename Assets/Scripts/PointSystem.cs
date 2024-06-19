using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public static float points;
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        
        textMesh.text = points.ToString("0");
        if (points == 0)
        {
            EnemySpawner.spawnTime = 0.5f;
        }
        if (points == 25)
        {
            EnemySpawner.spawnTime = 0.3f;
        }
        if (points == 50)
        {
            EnemySpawner.spawnTime = 0.1f;
        }
        if (points == 75)
        {
            EnemySpawner.spawnTime = 0.05f;
        }
    }

    public static void NewPoints(float newPoints)
    {
        points += newPoints;
    }
}