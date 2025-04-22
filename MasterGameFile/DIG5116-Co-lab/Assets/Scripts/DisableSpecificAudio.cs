using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpecificAudio : MonoBehaviour
{
    [Header("Task Related Options")]
    [SerializeField] GameManager GameManager;

    [Header("Audio Options")]
    [SerializeField] AudioSource audioSource;

    private void Update()
    {
        DisableTask3Audio();
    }
    private void DisableTask3Audio()
    {
        if (GameManager.isTask3Completed)
        {
            DisableAudio();
        }
    }
    private void DisableAudio()
    {
        if (audioSource != null)
        {
            audioSource.enabled = false;
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned.");
        }
    }
}
