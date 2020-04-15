using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;


    public GameObject Cloud;
    public GameObject GameOver;
    public int index;
    //public Button RestartButton;

    public Transform[] CloudPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;

        GameOver.SetActive(false);
        for (int i = 0; i <= CloudPosition.Length - 1; i++)
        {
            GameObject partical = Instantiate(Cloud, CloudPosition[i].position, Quaternion.identity);
        }
    }

    public void gameOver()
    {
        GameOver.SetActive(true);
    }
    public void Rstart()
    {
        SceneManager.LoadScene(index);
    }
    public void nextLevel()
    {
        if (index+1 != null)
            SceneManager.LoadScene(index+1);
    }

}
