using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator AscensorPuertaD1;
    public Animator AscensorPuertaI1;
    public Animator AscensorPuertaD2;
    public Animator AscensorPuertaI2;

    public RotateWorld PararMundo;
    public despeguecohete despegueactivar;

    public GameObject PuertaAsceD1;
    public GameObject PuertaAsceI1;
    public GameObject PuertaAsceD2;
    public GameObject PuertaAsceI2;

    public GameObject PuertaAsceD1deSubida;
    public GameObject PuertaAsceI1deSubida;
    public GameObject PuertaAsceD2deSubida;
    public GameObject PuertaAsceI2deSubida;

    public GameObject camaraPrincipal;
    public GameObject camaracohete;


    public GameObject correaAscensor;

    public Animator animator;
    public Animator fundidoaNegro;
    public Animator SoloANegro;

    public GameObject personaje;

    public float speedEngranaje = 60;
    public float speedAcensor = 1;

    public Transform engranajeAscensor;
    private bool giroengraje = false;

    public Transform ascensorSubida;

    public GameObject Mapaypersoanje;
    public GameObject cielo;
    public GameObject cielocohete;

    public GameObject cartelEnhorabuena;

    public GameObject elTiempo;

    
    public tiempo pararTiempo;

    public Pause pulsarPause;


    public GameObject sonidoCierraAscensor;
    public GameObject sonidosubirAscensor;

    public GameObject sonidoCohete;
    public AudioSource sonidoCohetebajando;

    public AudioSource sonidosSubidaAscensor;
    public AudioSource cancionPrincipalBajavolumen;
    public float fadeOutTime = 10.0f;
    public float VelocidadfadeOutTime = 20.0f;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            PararMundo.speedRot = 0;
            pararTiempo.enMarcha = false;


            animator.SetBool("Parado", true);


            AscensorPuertaD1.Play("cerrarAscensorD1");
            AscensorPuertaI1.Play("cerrarAscensorI1");
            AscensorPuertaD2.Play("cerrarAscensorD2");
            AscensorPuertaI2.Play("cerrarAscensorI2");
            sonidoCierraAscensor.SetActive(true);
            StartCoroutine("subirAscensor");
            StartCoroutine(FadeOut());

        }

    }
    IEnumerator subirAscensor()
    {
        yield return new WaitForSeconds(2f);
        personaje.SetActive(false);
        giroengraje = true;


        PuertaAsceD1deSubida.SetActive(true);
        PuertaAsceI1deSubida.SetActive(true);
        PuertaAsceD2deSubida.SetActive(true);
        PuertaAsceI2deSubida.SetActive(true);

        PuertaAsceD1.SetActive(false);
        PuertaAsceI1.SetActive(false);
        PuertaAsceD2.SetActive(false);
        PuertaAsceI2.SetActive(false);

        sonidosubirAscensor.SetActive(true);
        StartCoroutine(FadeOut());
        StartCoroutine(FadeOutCancionPrincipal());



        yield return new WaitForSeconds(7f);
        giroengraje = false;
        correaAscensor.SetActive(false);
        pulsarPause.puedePulsar = false;


        yield return new WaitForSeconds(1f);

        cartelEnhorabuena.SetActive(true);

        yield return new WaitForSeconds(8f);

        fundidoaNegro.SetBool("fundido", true);


        yield return new WaitForSeconds(1.8f);

        camaraPrincipal.SetActive(false);
        camaracohete.SetActive(true);

        Destroy(Mapaypersoanje);
        Destroy(cielo);
        cielocohete.SetActive(true);
        cartelEnhorabuena.SetActive(false);
        elTiempo.SetActive(false);





        yield return new WaitForSeconds(1f);
        fundidoaNegro.SetBool("fundido", false);
        despegueactivar.despeguecohetes = true;
        sonidoCohete.SetActive(true);

        yield return new WaitForSeconds(8f);

        StartCoroutine(bajasonidoCohete());



    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(5f);
        // Guarda el volumen inicial
        float startVolume = sonidosSubidaAscensor.volume;

        // Calcula el incremento por frame
        float fadeSpeed = startVolume / fadeOutTime;

        // Realiza el desvanecimiento
        while (sonidosSubidaAscensor.volume > 0)
        {
            sonidosSubidaAscensor.volume -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        // Aseg�rate de que el volumen sea cero al final
        sonidosSubidaAscensor.volume = 0;


    }
    IEnumerator FadeOutCancionPrincipal()
    {


        yield return new WaitForSeconds(1f);
        // Guarda el volumen inicial
        float startVolume = cancionPrincipalBajavolumen.volume;

        // Calcula el incremento por frame
        float fadeSpeed = startVolume / fadeOutTime;

        // Realiza el desvanecimiento
        while (cancionPrincipalBajavolumen.volume > 0)
        {
            cancionPrincipalBajavolumen.volume -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        // Aseg�rate de que el volumen sea cero al final
        cancionPrincipalBajavolumen.volume = 0;


    }
    IEnumerator bajasonidoCohete()
    {
        yield return new WaitForSeconds(5f);
        SoloANegro.SetBool("fundidoNegro", true);

        yield return new WaitForSeconds(0.3f);
        // Guarda el volumen inicial
        float startVolume = sonidoCohetebajando.volume;

        // Calcula el incremento por frame
        float fadeSpeed = startVolume / VelocidadfadeOutTime;

        // Realiza el desvanecimiento
        while (sonidoCohetebajando.volume > 0)
        {
            sonidoCohetebajando.volume -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        // Aseg�rate de que el volumen sea cero al final
        sonidoCohetebajando.volume = 0;

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Espacio");





    }
    void Update()
    {

        if (giroengraje == true)
        {
            engranajeAscensor.transform.Rotate(new Vector3(0f, 0f, -speedEngranaje) * Time.deltaTime);


            Vector3 translation = new Vector3(-speedAcensor, 0f, 0f);
            ascensorSubida.transform.Translate(translation * Time.deltaTime);

        }
    }
}
