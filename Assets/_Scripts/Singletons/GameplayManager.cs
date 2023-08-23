using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public GameObject[] dens;
    bool won = false;
    bool loss = false;
    public static GameplayManager instance;
    public bool started = false;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }    
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void getDens()
    {
        dens = GameObject.FindGameObjectsWithTag("Spawner");
        started = true;
    }
}
