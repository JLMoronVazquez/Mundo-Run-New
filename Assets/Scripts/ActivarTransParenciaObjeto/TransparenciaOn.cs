using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparenciaOn : MonoBehaviour
{
    public bool ok;
 
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

    // Cuando el personaje entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el personaje
        if (other.gameObject == muro1)
        {
            // Cambiar al Material 2
            rendererCaja.material = material2;
            ok = false;
        }
        // Verificar si colisiona con el muro invisible 2
        if (other.gameObject == muro2)
        {
            // Desactivar la caja (o puedes usar Destroy si prefieres eliminarla)
            gameObject.SetActive(false);
        }

    }

    //// opcional: cuando el personaje sale del trigger
    //private void ontriggerexit(collider other)
    //{
    //    if (other.comparetag("player"))
    //    {
    //        // volver al material 1
    //        renderercaja.material = material1;
    //    }
    //}
}



