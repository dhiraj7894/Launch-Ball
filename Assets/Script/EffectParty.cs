using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectParty : MonoBehaviour
{
    public static EffectParty instance;
    public GameObject paticalEffect;
    public GameObject SprayParticalObj;
    public Transform[] particalPosition;
    public Transform[] SprayPartical;
    private void Awake()
    {
        instance = this;
    }
    public void effect(float deathTime)
    {
        for (int i = 0; i <= particalPosition.Length - 1; i++)
        {
            GameObject partical = Instantiate(paticalEffect, particalPosition[i].position, Quaternion.identity);
            Destroy(partical, deathTime);
        }
        

    }
    public void SprayEffect(float deathTime)
    {
        for (int i = 0; i <= SprayPartical.Length - 1; i++)
        {
            GameObject partical = Instantiate(SprayParticalObj, SprayPartical[i].position, Quaternion.identity);
            //Destroy(partical, deathTime);
        }
    }
}
