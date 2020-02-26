using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour, IInteractable
{
    public string InteractabilityInfo { get { return "some text here"; } }

    public void ShowInteractability()
    {
        // Outline Shader maybe?
    }

    public void Interact()
    {
        print ("hello");
    }
}