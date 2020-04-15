using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectThrow : MonoBehaviour
{
    public static ObjectThrow instance;
    

    public GameObject player;
    public GameObject slider;
    public Slider powerCheck;
    public Rigidbody rb;

    int minForce=0;
    int launchForce;
    public int maxForce;
    public float time;
    /*public float time2 = 10;*/


   
    public bool isGoalReached = false;
    public bool bIsOnTheMove = false;
    bool isGrounded = false;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
        powerCheck.maxValue = maxForce;
        slider.SetActive(true);
        launchForce = minForce;
        StartCoroutine(timeUpdate());
        
    }
    void Update()
    {
        
        if (transform.position.y <= -5 || transform.position.y >= 85)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        powerCheck.value=launchForce;
        if (launchForce >= maxForce)
        {
            launchForce = minForce;
        }
    }
    public void launch()
    {
        bIsOnTheMove = true;
        slider.SetActive(false);
        if (isGrounded)
        {
            addForce();
        }
        /*StartCoroutine(Decresetime());*/
    }
    private void OnCollisionEnter(Collision other)
    {
        SoundManager.instancce.BallCollide();

        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            EffectParty.instance.effect(1f);
            StartCoroutine(ShowGameOverPanal());
        }
        if (other.gameObject.CompareTag("Glad"))
        {
            EffectParty.instance.SprayEffect(2f);
        }
    }
    public void setForce(int force)
    {
        time -= 0.01f;
        maxForce += force;
        
       powerCheck.maxValue = maxForce;
    }
    void addForce()
    { 
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * launchForce, ForceMode.VelocityChange);
    }
    IEnumerator timeUpdate()
    {
        while (launchForce <= maxForce)
        {
            launchForce += 5;
            yield return new WaitForSeconds(time);
        }
    }

    IEnumerator ShowGameOverPanal()
    {
        yield return new WaitForSeconds(1f);
        GameManager.gameManager.gameOver();
    }

}
