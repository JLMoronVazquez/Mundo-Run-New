using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaras : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed = 1;
    Transform currentView;

    public bool Camaraprincipal = false;
    public bool Camaraf1 = false;
    public bool Camaraonboard = false;


    void Start()
    {
        currentView = transform;
    }


    void Update()
    {

        if (Camaraprincipal == true)
        {
            currentView = views[0];
            Camaraf1 = false;
            Camaraonboard = false;
        }
        if (Camaraf1 == true)
        {
            currentView = views[1];
            Camaraprincipal = false;
            Camaraonboard = false;
        }
        if (Camaraonboard == true)
        {
            currentView = views[2];
            Camaraprincipal = false;
            Camaraf1 = false;
        }

    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Vector3 currentAngle = new Vector3(
            Mathf.Lerp(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.Lerp(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.Lerp(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
            );
        transform.eulerAngles = currentAngle;
    }
}
