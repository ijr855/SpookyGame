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
    private bool musicFadeInEnabled = false;
    private bool playMusic = true;
    private bool changeMusic = false;

    private bool firstRun = true;

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
        Debug.Log("AS " + audioSource.isPlaying);

        Debug.Log("CM " + changeMusic);

        Debug.Log("PM " + playMusic);

        Debug.Log("L " + location);

        Debug.Log("MFO " + musicFadeOutEnabled);

        if (SceneManager.GetActiveScene().name == "Level_One" && firstRun)
        {
            location = Locations.LEVEL_ONE;
            changeMusic = true;

            firstRun = false;
        }

        if (changeMusic == true && musicFadeOutEnabled == false)
        {
            FadeOutMusic();
            changeMusic = false;
            playMusic = false;
        }

        if (audioSource.isPlaying == false && playMusic == true && location == Locations.TITLE_SCREEN)
        {
            location = Locations.LEVEL_ONE;
            PlayMusic();
        }

        if (audioSource.isPlaying == false && playMusic == true && location != Locations.TITLE_SCREEN)
        {
            currentSong++;

            if (currentSong >= audioClips.Length)
            {
                PlayRandomMusic();
                currentSong = 1;
            } else
            {
                PlayRandomMusic();
            }

            musicFadeInEnabled = true;
        }

        if (musicFadeOutEnabled && audioSource.isPlaying == true)
        {
            if (audioSource.volume < 0.1f)
            {
                StopMusic();
                musicFadeOutEnabled = false;

                playMusic = true;

                changeMusic = false;
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

        if (musicFadeInEnabled && audioSource.isPlaying == true)
        {
            if (audioSource.volume > 0.49f)
            {
                musicFadeInEnabled = false;

                playMusic = false;

                changeMusic = false;
            }
            else
            {
                float newVolume = audioSource.volume + (0.1f * Time.deltaTime);
                if (newVolume > 0.25f)
                {
                    newVolume = 0.25f;
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
