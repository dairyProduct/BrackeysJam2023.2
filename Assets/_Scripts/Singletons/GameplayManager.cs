using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public GameObject[] dens;
    public GameObject player;
    public bool won = false;
    public bool loss = false;
    public static GameplayManager instance;
    public bool started = false;
    public TextMeshProUGUI ggtext;

    float restartTimer = 0f;
    float restartTime = 2f;
    bool startTimer = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //getDens();
    }




    private void Update()
    {
        if (!started)
        {
            return;
        }
        else
        {
            won = checkForWin();
            if (won)
            {
                ggtext.text = "You've eaten the rich!";
                ggtext.color = Color.green;
                startTimer = true;
            }
            loss = checkForLoss();
            if (loss)
            {
                ggtext.text = "You've perished to the 1%";
                ggtext.color = Color.red;
                startTimer = true;
            }
        }
        if(startTimer)
        {
            restartTimer += Time.deltaTime;
            if(restartTimer > restartTime)
            {
                startOver();
            }
        }
    }


    bool checkForWin() //probably want to add logic about reaching "end"
    {
        foreach (var den in dens)
        {
            if(den != null)
            {
                return false;
            }
        }
        return true;
    }

    bool checkForLoss()
    {
        if(player == null)
        {
            return true;
        }
        return false;
    }

    public void getDens()
    {
        dens = GameObject.FindGameObjectsWithTag("Spawner");
        player = GameObject.FindWithTag("Player");
        started = true;
    }

    void startOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
