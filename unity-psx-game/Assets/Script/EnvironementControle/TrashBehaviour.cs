using UnityEngine;

public class TrashBehaviour : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "DumbTrigger")
        {
            Destroy(gameObject);
        }
    }
}
