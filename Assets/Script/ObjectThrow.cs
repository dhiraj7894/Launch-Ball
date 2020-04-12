using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectThrow : MonoBehaviour
{

    public GameObject player;
    public Slider powerCheck;

    int minForce=0;
    int launchForce;
    public int maxForce = 70;
    public float time;

    bool isGrounded = false;

    private void Start()
    {
        launchForce = minForce;
        StartCoroutine(timeUpdate());
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        powerCheck.value=launchForce;
        if (launchForce >= 70)
        {
            launchForce = minForce;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                addForce();
            }
           
        } 
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
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
}
