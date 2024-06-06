using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despeguecohete : MonoBehaviour
{
    public float speedAcensor = 100;


    public bool despeguecohetes = false;

    public Transform cohete;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (despeguecohetes == true)
        {

            Vector3 translation = new Vector3(0f, speedAcensor, 0f);
            cohete.transform.Translate(translation * Time.deltaTime);

        }



    }
}
