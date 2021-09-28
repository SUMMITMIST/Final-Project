using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInDefeat : MonoBehaviour
{

    AudioSource audioDefeat;

    void Start()
    {
        audioDefeat = GetComponent<AudioSource>();

        audioDefeat.Play();
    }
}
