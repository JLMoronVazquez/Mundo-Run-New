using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionBarco : MonoBehaviour
{
    public float speed = 10f;

    public float movimientoLados = 0;

    public float LimitedePistaPositivo = 3;
    public float LimitedePistanegativo = -3;

    public RotateWorld PararMundo;


    public BoxCollider Choque;


    public bool botonA = true;


    public float MovMuroInvisible = 5f;


    public float VelocidadBarco = 0;
    public float AceleradorBarco = 12;
    public bool AceleradorInicioBarco = false;
    public bool MaxVelocidadBarco = false;



    public float PosicionZ = 0.45f;
    public float VelocidadvolveposicionZ = 10f;


    public bool GiraLasRuedas = true;
    public float valorLimitenegativo = -2.9f;
    public float valorLimitepositivo = 2.9f;



    public bool activarRemolino = false;


    public GameObject Barco;

    public GameObject PersonajePrincipal;

    public FuncionBarco funcionBarco;

    public Transform barco;


    public Animator animatorRemolino;

    public AudioSource sonidovueltas;





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
        //if (transform.position.y > 24)
        //{
        //    transform.position = new Vector3(transform.position.x, 24f, transform.position.z);
        //}
        //if (transform.position.z < -0.3)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
        //}
        //if (transform.position.z > 0.25)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, 0.25f);
        //}

        if (AceleradorInicioBarco == true)
        {
            VelocidadBarco += Time.deltaTime * AceleradorBarco;

            if (VelocidadBarco > 19)
            {
                AceleradorInicioBarco = false;
            }
            PararMundo.speedRot = VelocidadBarco;
        }




        if (transform.position.z < PosicionZ)
        {
            float newZ = Mathf.Lerp(transform.position.z, PosicionZ, VelocidadvolveposicionZ * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        }



        Vector3 posicion = transform.position;

        //if(activarRemolino == false)
        //{
        //    barco.transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
        //}
        //else if (activarRemolino == true)
        //{
        //    barco.transform.Rotate(new Vector3(0f, -remolinoBarco, 0f) * Time.deltaTime);
        //}



    }
    IEnumerator Vuelveacorrer()
    {
        yield return new WaitForSeconds(0.2f);
        //HijoF1.parent = PadreNivel3;
        PararMundo.speedRot = 10;

    }
    IEnumerator DestruirF1()
    {
        yield return new WaitForSeconds(2f);
        //Destroy(F1Antiguo);
    }
    public void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Remolino"))
        {
            PararMundo.speedRot = 10;
            animatorRemolino.SetBool("activarremolino", true);
            //animatorRemolino.Play("remolino");
            sonidovueltas.Play();


        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Remolino"))
        {

            PararMundo.speedRot = 19;
            animatorRemolino.SetBool("activarremolino", false);


        }
    }
    public void OnCollisionStay(Collision collision)
    {

        if (collision.collider.CompareTag("Untagged"))
        {
            PararMundo.speedRot = 0;










        }

    }
    public void OnCollisionExit(Collision collision)
    {

        if (collision.collider.CompareTag("Untagged"))
        {
            PararMundo.speedRot = 19;


        }




    }
}
