using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followObject;
    private Vector3 moveTemp;
    public float offsetY = 2;
    public float offsetX = 2;


    void Start()
    {
        moveTemp = followObject.transform.position;
    }

    void Update()
    {

        moveTemp = followObject.transform.position;
        moveTemp.y += offsetY;
        moveTemp.x += offsetX;
        moveTemp.z = transform.position.z;
        transform.position = moveTemp;
    }
}
