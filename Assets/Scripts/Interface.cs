using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string InteractabilityInfo { get; }

    void ShowInteractability();

    void Interact();
}
