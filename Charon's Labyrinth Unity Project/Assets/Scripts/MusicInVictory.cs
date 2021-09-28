using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInVictory : MonoBehaviour
{
    AudioSource audioVictory;

    void Start()
    {
        audioVictory = GetComponent<AudioSource>();

        audioVictory.Play();
    }
}
