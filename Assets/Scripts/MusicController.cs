using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    int currentSong = 0;
    private bool musicFadeOutEnabled = false;
    private bool playMusic = true;
    private bool changeMusic = false;

    private enum Locations { TITLE_SCREEN, LEVEL_ONE }
    private Locations location = Locations.TITLE_SCREEN;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[0];
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level_One")
        {
            location = Locations.LEVEL_ONE;
            changeMusic = true;
        }

        if (changeMusic == true && musicFadeOutEnabled == false)
        {
            FadeOutMusic();
            changeMusic = false;
            playMusic = false;
        }

        if (audioSource.isPlaying == false && playMusic == true && location == Locations.TITLE_SCREEN)
        {
            PlayMusic();
        }

        if (audioSource.isPlaying == false && playMusic == true && location != Locations.TITLE_SCREEN)
        {
            currentSong++;
            if (currentSong >= audioClips.Length)
            {
                currentSong = 1;
                PlayRandomMusic();
            }
        }

        if (musicFadeOutEnabled && audioSource.isPlaying == true)
        {
            if (audioSource.volume <= 0.1f)
            {
                StopMusic();
                musicFadeOutEnabled = false;
            }
            else
            {
                float newVolume = audioSource.volume - (0.3f * Time.deltaTime);
                if (newVolume < 0f)
                {
                    newVolume = 0f;
                }
                audioSource.volume = newVolume;
            }
        }
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void PlaySpecificMusic(int i)
    {
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }

    public void PlayRandomMusic()
    {
        audioSource.clip = audioClips[Random.Range(1, audioClips.Length)];
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void FadeOutMusic()
    {
        musicFadeOutEnabled = true;
    }
}
