using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivator : MonoBehaviour
{
    private bool onPause = false;
    public RightArm rightArm;
    public LeftArm leftArm;
    

    public void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            onPause = !onPause;

            if(onPause)
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
}
