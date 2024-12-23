using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [HideInInspector] public bool isFinished = false;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

    private void Update()
    {
        isFinished = DialogueManager.instance.isDialogueFinished;
    }
}
