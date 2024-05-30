using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMesh;
    public string textValue;
    public float TextRemains;
    public bool newText = true;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        TextRemains = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TextRemains >= 35.0f)
        {
            if (newText)
            {
                textValue = " ";
                newText = false;
            }
            TextRemains = 0;
        }
        TextRemains += 0.01f;

        textMesh.text = textValue;
    }
}


