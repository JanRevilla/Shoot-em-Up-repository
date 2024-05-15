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
        if (points >= 100)
        {
            EnemySpawner.spawnTime = 2.0f;
        }
        if (points >= 200)
        {
            EnemySpawner.spawnTime = 1.0f;
        }
        if (points >= 300)
        {
            EnemySpawner.spawnTime = 0.5f;
        }
        if (points >= 400)
        {
            EnemySpawner.spawnTime = 0.3f;
        }
        if (points >= 500)
        {
            EnemySpawner.spawnTime = 0.1f;
        }
    }

    public static void NewPoints(float newPoints)
    {
        points += newPoints;
    }
}