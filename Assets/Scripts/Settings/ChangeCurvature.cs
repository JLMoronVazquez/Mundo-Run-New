using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCurvature : MonoBehaviour
{
    [Range(-0.01f, 0.01f)]
    public float curvature;

    // Start is called before the first frame update
    void Start()
    {
        int propertyId = Shader.PropertyToID("_CurvaMundo");
        Shader.SetGlobalFloat(propertyId, curvature);
    }

    void OnApplicationQuit()
    {
        int propertyId = Shader.PropertyToID("_CurvaMundo");
        Shader.SetGlobalFloat(propertyId, 0);
    }

}


