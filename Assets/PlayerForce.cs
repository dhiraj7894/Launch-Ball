using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    [SerializeField] private Transform forceTransform;

    private void Awake()
    {
        //  forceSpriteMask = forceTransform.Find("mask").GetComponent<SpriteMask>();
    }
    void Update()
    {
        forceTransform.position = transform.position;
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        forceTransform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));

    }
    [SerializeField]
    public const float MAX_FORCE = 80f;


    public  void Launch(float force)
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * -1f;
        transform.GetComponent<Rigidbody>().velocity = dir * force;
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
