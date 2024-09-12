using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparenciaOn : MonoBehaviour
{
 
    // Referencias a los materiales
    public Material material1;
    public Material material2;

    // Referencias a los muros
    public GameObject muro1;  // Muro que cambia el material
    public GameObject muro2;  // Muro que hace desaparecer la caja

    // Referencia al renderer de la caja
    private Renderer rendererCaja;

    // Inicializar la referencia al renderer de la caja
    void Start()
    {
        rendererCaja = GetComponent<Renderer>();
    }

    // Detectar colisiones
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si colisiona con el muro invisible 1
        if (collision.gameObject == muro1)
        {
            // Cambiar al Material 2
            rendererCaja.material = material2;
        }

        // Verificar si colisiona con el muro invisible 2
        if (collision.gameObject == muro2)
        {
            // Desactivar la caja (o puedes usar Destroy si prefieres eliminarla)
            gameObject.SetActive(false);
        }
    }
}



