using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    [SerializeField] private Animator doorAnimator;

    public void Interact()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);
    }
}
