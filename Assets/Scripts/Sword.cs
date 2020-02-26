using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sword : MonoBehaviour, IInteractable
{
    public string InteractabilityInfo { get { return "some text here"; } }

    public void ShowInteractability()
    {
        // Outline Shader maybe?
    }

    public void Interact()
    {
        print("this should take me to the next scene");
        SceneManager.LoadScene("WinScene");
    }
}
