using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyExitMovement : MonoBehaviour
{
    public float smoothingKey;
    //public float xX;
    //public float yY;
    //public float zZ;

    void Update()
    {

        Vector3 keyDestinationPoint = new Vector3(27.232f, 0.805f, 26.33f);
        //Плавное "скольжение" из одной точки в другую
        gameObject.transform.position = Vector3.Lerp(transform.position, keyDestinationPoint, smoothingKey * Time.deltaTime);
    }
}
