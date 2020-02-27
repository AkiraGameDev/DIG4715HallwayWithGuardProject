using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    public GameObject camera;
    private MouseLook mouseLook;
    private float xSens;
    private float ySens;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        mouseLook = camera.GetComponent<MouseLook>();
        xSens = mouseLook.xSensitivity;
        ySens = mouseLook.ySensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        mouseLook.xSensitivity = xSens;
        mouseLook.ySensitivity = ySens;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        mouseLook.xSensitivity = 0;
        mouseLook.ySensitivity = 0;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }

}
