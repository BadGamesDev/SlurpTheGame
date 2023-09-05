using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip twitchAlertSound;
    public AudioClip johnCenaSound;
    public AudioClip freezeSound;
    public AudioClip recordScratchSound;
    public AudioClip ultimateShowdownSound;

    private AudioSource audioSource;
    public bool isUltimateShowdownPlaying = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayUltimateShowdown();
    }

    public void PlayTwitchAlert()
    {
        audioSource.PlayOneShot(twitchAlertSound);
    }

    public void PlayJohnCena()
    {
        audioSource.PlayOneShot(johnCenaSound);
    }

    public void PlayFreeze()
    {
        audioSource.PlayOneShot(freezeSound);
    }

    public void PlayRecordScratch()
    {
        audioSource.PlayOneShot(recordScratchSound);
    }

    public void PlayUltimateShowdown()
    {
        if (!isUltimateShowdownPlaying)
        {
            audioSource.clip = ultimateShowdownSound;
            audioSource.loop = true;
            audioSource.Play();
            isUltimateShowdownPlaying = true;
        }
    }

    public void PauseUltimateShowdown()
    {
        if (isUltimateShowdownPlaying)
        {
            audioSource.Stop();
            isUltimateShowdownPlaying = false;
        }
    }

    public void ContinueUltimateShowdown()
    {
        if (!isUltimateShowdownPlaying)
        {
            audioSource.UnPause();
            isUltimateShowdownPlaying = true;
        }
    }
}
