using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRaycast : MonoBehaviour
{
    private const int RANGE = 3;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, RANGE))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.ShowInteractability();

                if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1"))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
