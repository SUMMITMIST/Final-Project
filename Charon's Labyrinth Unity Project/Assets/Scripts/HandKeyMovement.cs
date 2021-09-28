using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandKeyMovement : MonoBehaviour
{
    Vector3 destinationPoint = new Vector3 (1f, 0.8f, 5.562f);
    
    public float smoothing;
    void Update()
    {
        //Плавное "скольжение" из одной точки в другую
        gameObject.transform.position = Vector3.Lerp(transform.position, destinationPoint, smoothing * Time.deltaTime);
    }
}
