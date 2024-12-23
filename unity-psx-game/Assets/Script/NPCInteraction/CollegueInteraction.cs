using UnityEngine;
using System.Collections;

public class CollegueInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    public void Interact()
    {
        dialogueTrigger.TriggerDialogue();
    }
}
