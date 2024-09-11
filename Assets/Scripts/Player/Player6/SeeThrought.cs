using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrought : MonoBehaviour
{
    public static int posID = Shader.PropertyToID("_PlayerPosition");
    public static int sizeID = Shader.PropertyToID("_SizeWindowPlayer");
    public LayerMask mask;

    private Camera cam;
    public float circleSize;
    public float offsetDown;

    public void Start()
    {
        cam = Camera.main;
    }

    public void Update()
    {

        Vector3 playerPosDir = cam.transform.position - transform.position;
        Ray ray = new Ray(transform.position, playerPosDir.normalized);
        if (Physics.Raycast(ray, 3000, mask))
        {
            Shader.SetGlobalFloat(sizeID, circleSize);
        }
        else
        {
            Shader.SetGlobalFloat(sizeID, 0);
        }

        Vector3 posWithOffset = transform.position;
        posWithOffset.y -= offsetDown;
        Vector3 playerPosView = cam.WorldToViewportPoint(posWithOffset);
        playerPosView.y += 0.1f;
        Shader.SetGlobalVector(posID, playerPosView);
    }
}
