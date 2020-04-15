using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instancce;

    public AudioSource source;
    public AudioClip Ball, force;

    private void Start()
    {
        instancce = this;
    }

    public void BallCollide()
    {
        source.clip = null;
        source.clip = Ball;
        source.Play();
    }
    public void ForceAdd()
    {
        source.clip = null;
        source.clip = force;
        source.Play();
    }
}
