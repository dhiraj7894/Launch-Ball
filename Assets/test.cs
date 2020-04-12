using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private PlayerForce ball;
    private float holdDownStartTime;

    float force;
    float holdTimeNormalized;
    float maxForceHoldDownTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time; 
        }
        if (Input.GetMouseButton(0))
        { 
            float holdDownTime = Time.time - holdDownStartTime;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            ball.Launch(calHoldForce(holdDownStartTime));
        }
        Debug.Log(holdDownStartTime + " " + force + " " + holdTimeNormalized);
    }

    private float calHoldForce(float holdTime)
    {

        maxForceHoldDownTime = 3f;
        holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        force = holdTimeNormalized * PlayerForce.MAX_FORCE;

        
        return force;
    }
}
