using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public Transform fingerTip;
    public float distanceToActivate;
    public float timeToActivateAgain;

    private float timerToActivateAgain;
    private bool preesed = false;

    public void Awake()
    {
        timerToActivateAgain = timeToActivateAgain;
    }

    public void Update()
    {
        if (!preesed)
        {
            CheckPress();
        }
        else
        {
            CountTimer();
        }

    }

    public void CheckPress()
    {
        if (Vector3.Distance(fingerTip.position, transform.position) < distanceToActivate)
        {
            print("asdasdsdasd");
            preesed = true;
        }
    }

    public void CountTimer()
    {
        timerToActivateAgain -= Time.unscaledDeltaTime;
        if( timerToActivateAgain < 0 )
        {
            preesed = false;
            timerToActivateAgain = timeToActivateAgain;
        }
    }
}
