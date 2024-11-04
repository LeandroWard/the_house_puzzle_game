using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }

    public AudioSource musicSource;    // Para la m�sica de fondo
    public AudioSource sfxSource;      //  Para los efectos de sonido

    private void Awake()
    {
        // Configura el singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Configura el AudioSource para m�sica
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true;

            // Configura el AudioSource para efectos de sonido
            sfxSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // Destruir duplicados
        }
    }

    // M�todo para cambiar la m�sica
    public void ChangeMusic(AudioClip newClip, float volume = 0.5f)
    {
        if (musicSource.clip == newClip) return; // Evitar repetir la misma canci�n

        musicSource.Stop();
        musicSource.clip = newClip;
        musicSource.volume = volume;
        musicSource.Play();
    }

    // M�todo para reproducir efectos de sonido
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        sfxSource.PlayOneShot(clip, volume); // Reproduce el clip de sonido sin interrumpir la m�sica
    }
}