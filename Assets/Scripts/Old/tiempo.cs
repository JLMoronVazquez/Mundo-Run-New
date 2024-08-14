using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class tiempo : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempos;


    public float restante;
    public bool enMarcha = false;

    public GameObject findelTiempo;
    public GameObject sonidoFindelTiempo;

    public GameObject sonidoCuentaAtras;



    public Pause pulsarPause;

    private void Awake()
    {
        restante = (min * 60) + seg;

    }



    void Update()
    {
        if (restante <= 60 & restante >= 30)
        {
            tiempos.color = Color.yellow;

        }
        if (restante <= 30)
        {
            tiempos.color = Color.red;

        }
        if (restante <= 10)
        {
            sonidoCuentaAtras.SetActive(true);

        }

        if (enMarcha)
        {
            restante -= Time.deltaTime;

            if (restante < 1)
            {
                //Termina El juego

                Time.timeScale = 0;
                sonidoFindelTiempo.SetActive(true);

                findelTiempo.SetActive(true);

                pulsarPause.puedePulsar = false;
                AudioSource[] audios = FindObjectsOfType<AudioSource>();

                foreach (AudioSource a in audios)
                {
                    if (a.CompareTag("nodetener"))
                    {
                        continue;

                    }

                    a.Stop();

                }

            }


            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempos.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);

        }
    }
}
