using UnityEngine;

public class CollegueInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] DialogueTrigger dialogueTrigger;

    public void Interact()
    {
        dialogueTrigger.TriggerDialogue();
    }
}
