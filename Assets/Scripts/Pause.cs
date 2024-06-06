using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool puedePulsar = false;
    private bool isPaused = false;
    public GameObject pausePanel;

    public tiempo pararTiempo;

    public AudioSource musicaPause;

    void Update()
    {
        if (puedePulsar == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {

            pararTiempo.enMarcha = false;
            Time.timeScale = 0; // Pausa el tiempo
            pausePanel.SetActive(true); // Activa el panel de pausa

            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                musicaPause.Play();
                a.Pause();
            }


        }
        else
        {
            pararTiempo.enMarcha = true;
            Time.timeScale = 1; // Reanuda el tiempo
            pausePanel.SetActive(false); // Desactiva el panel de pausa


            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {

                a.Play();
            }


        }
    }
}
