using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour, IInteractable
{
    public GameObject instructions;
    public GameObject camera;
    public string InteractabilityInfo { get { return "some text here"; } }
    private MouseLook mouseLook;
    private float xSens;
    private float ySens;

    void Start()
    {
        instructions.SetActive(false);
        mouseLook = camera.GetComponent<MouseLook>();
        xSens = mouseLook.xSensitivity;
        ySens = mouseLook.ySensitivity;
    }

    public void ShowInteractability()
    {
        // Outline Shader maybe?
    }

    public void Interact()
    {
        instructions.SetActive(true);
        mouseLook.xSensitivity = 0;
        mouseLook.ySensitivity = 0;
    }

    void Update()
    {
        
        if (Input.anyKeyDown && instructions.activeInHierarchy && !Input.GetKeyDown(KeyCode.E) && !Input.GetButtonDown("Fire1"))
        {
            instructions.SetActive(false);
            mouseLook.xSensitivity = xSens;
            mouseLook.ySensitivity = ySens;
        }
    }
}