using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    public AudioClip deathMusic;

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void Update()
    {
        // Verifica si el tiempo est� detenido
        if (Time.timeScale == 0.0f && audioSource.clip != deathMusic)
        {
            ChangeMusic(deathMusic);
        }
        else if (Time.timeScale > 0.0f && audioSource.clip != backgroundMusic)
        {
            ChangeMusic(backgroundMusic);
        }
    }

    // M�todo para cambiar la m�sica
    private void ChangeMusic(AudioClip newClip)
    {
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }

    // M�todo para reproducir la m�sica de fondo
    private void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; 
        audioSource.Play(); 
    }
}
