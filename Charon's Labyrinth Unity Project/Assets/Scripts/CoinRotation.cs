using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float speedX = 5.0f;
    public GameObject target;

    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, speedX * Time.deltaTime);
    }



}
