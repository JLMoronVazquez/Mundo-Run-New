using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivator : MonoBehaviour
{
    private bool onPause = false;
    public RightArm rightArm;
    public LeftArm leftArm;
    public float timeToMove;

    private float timerToMove;

    public void Awake()
    {
        rightArm.GetComponent<Arm>().timeToMove = timeToMove;
        leftArm.GetComponent<Arm>().timeToMove = timeToMove;
    }


    public void Update()
    {
        timerToMove -= Time.unscaledDeltaTime;
        if( timerToMove > 0 )
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timerToMove = timeToMove;
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        onPause = !onPause;

        if (onPause)
        {
            Time.timeScale = 0f;
            rightArm.ActivateArm();
            leftArm.ActivateArm();
        }
        else
        {
            Time.timeScale = 1;
            rightArm.DeActivateArm();
            leftArm.DeActivateArm();
        }
    }
}
