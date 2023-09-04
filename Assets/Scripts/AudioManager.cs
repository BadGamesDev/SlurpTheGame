using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip twitchAlertSound;
    public AudioClip johnCenaSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTwitchAlert()
    {
        audioSource.PlayOneShot(twitchAlertSound);
    }

    public void PlayJohnCena()
    {
        audioSource.PlayOneShot(johnCenaSound);
    }
}
