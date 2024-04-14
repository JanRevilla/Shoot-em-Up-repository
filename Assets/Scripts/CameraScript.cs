using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target; // targetear a nuestro jugador

    private float target_poseX; // posicion x del jugador
    private float target_poseY; // posicion y del jugador

    private float posX; // posicion x camara
    private float posY; // posicion y camara

    public float derechaMax; // maximo desplazamiento de la camara (derecha)
    public float izquierdaMax; // maximo desplazamiento de la camara (izquierda)

    public float alturaMax; // altura maxima de la camara
    public float alturaMin; // altura minima de la camara

    public float speed; // velocidad de la camara
    public bool encendida; // camara encendida

    void Awake()
    {
        posX = target_poseX + derechaMax;
        posY = target_poseY + alturaMin;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), 1);
    }

    void MoveCam()
    {
        if (encendida)
        {
            if (target)
            {
                target_poseX = target.transform.position.x;
                target_poseY = target.transform.position.y;

                if (target_poseX > derechaMax && target_poseX < izquierdaMax)
                {
                    posX = target_poseX +1.0f;
                }   
                if (target_poseY < alturaMax && target_poseY > alturaMin)
                {
                    posY = target_poseY;
                }
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed*Time.deltaTime);

        }
    }
    void Update()
    {
        MoveCam();
    }
}

