using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionF1 : MonoBehaviour
{
    public float speed = 10f;

    public float movimientoLados = 0;

    public float LimitedePistaPositivo = 3;
    public float LimitedePistanegativo = -3;

    public RotateWorld PararMundo;


    public BoxCollider Choque;


    public bool botonA = true;


    public float MovMuroInvisible = 5f;


    public float VelocidadF1 = 0;
    public float AceleradorF1 = 15;
    public bool AceleradorCoche = false;
    public bool MaxVelocidadCoche = false;
    public bool RoturaMotorCoche = false;
    public float AceleradorMASF1 = 20;

    public float FrenaF1 = 15;


    public float PosicionZ = 0.45f;
    public float VelocidadvolveposicionZ = 10f;


    public bool GiraLasRuedas = true;
    public float valorLimitenegativo = -2.9f;
    public float valorLimitepositivo = 2.9f;


    public bool PararRoturaMotor = false;

    public GameObject PilotoBrazosFuera;
    public GameObject PilotoCuerpoFuera;
    public GameObject CascoPiloto;
    public GameObject F1Antiguo;

    public GameObject PersonajePrincipal;

    public FuncionF1 funcionf1;
    public GiroRueda giroruedas;

    public Transform PadreNivel3;
    public Transform HijoF1;

    public GameObject Humo;
    public Animator HumoMotor;


    public AudioSource sonidoF1velocidad;

    public GameObject sonidoF1Maxvelocidad;

    public Transform F1;
    public float speedHaciatras = 1;
    public float speedHaciatrasinPiloto = 10;
    private void Start()
    {
        PararMundo = FindObjectOfType<RotateWorld>();

        //currentNumber = VelocidadMaxF1;

        //rb = GetComponent<Rigidbody>();

        //animator = GetComponent<Animator>();




    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);

        transform.position = transform.position + movementDirection * speed * Time.deltaTime;


        if (transform.position.x > LimitedePistaPositivo)
        {
            transform.position = new Vector3(LimitedePistaPositivo, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < LimitedePistanegativo)
        {
            transform.position = new Vector3(LimitedePistanegativo, transform.position.y, transform.position.z);
        }


        if (AceleradorCoche == true)
        {
            VelocidadF1 += Time.deltaTime * AceleradorF1;


            if (VelocidadF1 > 40)
            {

                AceleradorCoche = false;
                StartCoroutine("sonidoF1Velocidad");
            }
            PararMundo.speedRot = VelocidadF1;
        }
        if (MaxVelocidadCoche == true)
        {
            VelocidadF1 += Time.deltaTime * AceleradorMASF1;
            sonidoF1Maxvelocidad.SetActive(true);
            sonidoF1velocidad.Stop();

            if (VelocidadF1 > 100)
            {

                MaxVelocidadCoche = false;
                AceleradorCoche = false;
                Humo.SetActive(true);
                HumoMotor.Play("HumoRoturaCoche");
                sonidoF1Maxvelocidad.SetActive(false);


            }
            PararMundo.speedRot = VelocidadF1;
        }

        if (RoturaMotorCoche == true)
        {
            VelocidadF1 -= Time.deltaTime * FrenaF1;

            Vector3 translation = new Vector3(0f, 0f, speedHaciatras);
            F1.transform.Translate(translation * Time.deltaTime);

            if (VelocidadF1 <= 1)
            {
                PararRoturaMotor = true;

                RoturaMotorCoche = false;
            }
            PararMundo.speedRot = VelocidadF1;

        }
        if (PararRoturaMotor == true)
        {
            PararMundo.speedRot = 0;
            Destroy(PilotoBrazosFuera);
            Destroy(PilotoCuerpoFuera);
            CascoPiloto.SetActive(true);
            PersonajePrincipal.SetActive(true);
            funcionf1.enabled = false;
            giroruedas.enabled = false;

            StartCoroutine("Vuelveacorrer");
            StartCoroutine("DestruirF1");

        }


        if (transform.position.z < PosicionZ)
        {
            float newZ = Mathf.Lerp(transform.position.z, PosicionZ, VelocidadvolveposicionZ * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        }



        Vector3 posicion = transform.position;
        if (posicion.x >= valorLimitenegativo && posicion.x <= valorLimitepositivo)
        {
            GiraLasRuedas = false;
        }
        else
        {
            GiraLasRuedas = true;
        }





    }
    IEnumerator sonidoF1Velocidad()
    {
        yield return new WaitForSeconds(2f);
        sonidoF1velocidad.Play();
    }
    IEnumerator Vuelveacorrer()
    {
        yield return new WaitForSeconds(0.2f);
        HijoF1.parent = PadreNivel3;
        PararMundo.speedRot = 10;
        Vector3 translation = new Vector3(0f, 0f, speedHaciatrasinPiloto);
        F1.transform.Translate(translation * Time.deltaTime);

    }
    IEnumerator DestruirF1()
    {
        yield return new WaitForSeconds(2f);
        Destroy(F1Antiguo);
    }
    public void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Trafico"))
        {
            PararMundo.speedRot = 20;


        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trafico"))
        {

            PararMundo.speedRot = 40;


        }
    }
}
