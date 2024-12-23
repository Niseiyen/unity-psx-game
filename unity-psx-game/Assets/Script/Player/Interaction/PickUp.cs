using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] float pickUpRange = 5f;
    [SerializeField] float moveForce = 250f;
    [SerializeField] Transform holdParent;
    private GameObject heldObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.tag == "canPickUp")
                    {
                        PickUpObject(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObj != null)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position).normalized;
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    private void PickUpObject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>())
        { 
            Rigidbody rb = pickObj.GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.linearDamping = 10;

            rb.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    private void DropObject() 
    {
        Rigidbody rb = heldObj.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.linearDamping = 0f;
        rb.transform.parent = null;
        heldObj = null;
    }
}
