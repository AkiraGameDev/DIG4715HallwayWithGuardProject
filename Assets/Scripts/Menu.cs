using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start");
    }

    public void Quit()
    {
        print("Quit");
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            print("Quit");
            Application.Quit();
        }

        if(Input.GetButtonDown("Menu1"))
        {
            Game();
        }
        if(Input.GetButtonDown("Menu2"))
        {
            Quit();
        }
        if(Input.GetButtonDown("Menu3"))
        {
            Credits();
        }
    }
}
