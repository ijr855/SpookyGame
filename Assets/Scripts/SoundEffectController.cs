using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundEffectController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    int currentSoundEffect = 0;
    private bool soundEffectFadeOutEnabled = false;
    private bool playStartDemonSoundEffect = true;
    private bool changeSoundEffect = false;
    private bool delaySoundEffect = true;

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
        if (SceneManager.GetActiveScene().name == "Level_One")
        {
            location = Locations.LEVEL_ONE;
        }

        if(location == Locations.LEVEL_ONE && audioSource.isPlaying == false && playStartDemonSoundEffect == true && delaySoundEffect == true)
        {
            StartCoroutine(playLevel_OneDemon());
            playStartDemonSoundEffect = false;
        }

        if (changeSoundEffect == true && soundEffectFadeOutEnabled == false && playStartDemonSoundEffect == true)
        {
            FadeOutSoundEffect();
            changeSoundEffect = false;
            playStartDemonSoundEffect = false;
        }

        if (soundEffectFadeOutEnabled && audioSource.isPlaying == true)
        {
            if (audioSource.volume <= 0.1f)
            {
                StopSoundEffect();
                soundEffectFadeOutEnabled = false;
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

    public void PlaySoundEffect()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void PlaySpecificSoundEffect(int i)
    {
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }

    public void PlayRandomSoundEffect()
    {
        audioSource.clip = audioClips[Random.Range(1, audioClips.Length)];
        audioSource.Play();
    }

    public void StopSoundEffect()
    {
        audioSource.Stop();
    }

    public void FadeOutSoundEffect()
    {
        soundEffectFadeOutEnabled = true;
    }

    IEnumerator playLevel_OneDemon()
    {
        yield return new WaitForSeconds(5);
        PlaySoundEffect();
    }
}
