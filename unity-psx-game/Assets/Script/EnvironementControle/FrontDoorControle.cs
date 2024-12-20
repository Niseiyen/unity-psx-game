using UnityEngine;

public class FrontDoorControle : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("isOpen", true);
        }

        if(other.CompareTag("NPC"))
        {
            doorAnimator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("isOpen", false);
        }

        if(other.CompareTag("NPC"))
        {
            doorAnimator.SetBool("isOpen", false);
        }
    }
}

