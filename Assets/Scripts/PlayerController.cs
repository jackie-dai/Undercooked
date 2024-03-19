using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Variables
    [SerializeField]
    private float moveSpeed;
    #endregion

    #region Private Variables
    private Rigidbody2D rb;
    private Vector3 currDirection;

    private float interactRange;
    private bool isHoldingItem;
    private GameObject currentItemHeld;
    [SerializeField]
    private float itemOffset;


    #endregion

    #region Unity Functions
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        interactRange = 1f;
        isHoldingItem = false;
        currentItemHeld = null;
        itemOffset = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Q) && currentItemHeld != null)
        {
            DropItem();
        }

        Move();
    }
    #endregion

    #region User Functions
    #endregion

    #region Helper functions
    /* Make player move */
    void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (inputX < 0)
        {
            currDirection = Vector3.left;
        }
        else if (inputX > 0)
        {
            currDirection = Vector3.right;
        }
        else if (inputY < 0)
        {
            currDirection = Vector3.down;
        }
        else if (inputY > 0)
        {
            currDirection = Vector3.up;
        }

        Vector2 moveDirection = new Vector2(inputX, inputY);
        rb.velocity = moveDirection * moveSpeed;
    }

    /* Check if item ahead is a PickableItem, Station, or Table. If so, perform specific action */
    private void Interact()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(rb.position, Vector2.one, 0f, currDirection, interactRange);
        foreach (RaycastHit2D hit in hits)
        {
            Debug.Log("item hit: " + hit.transform.name);
            if (hit.transform.CompareTag("PickableItem"))
            {
                PickupItem(hit.transform);
                Debug.Log("Pickup item");
            }
            else if (hit.transform.CompareTag("Station"))
            {
                Debug.Log("Activate station");
            }
            else if (hit.transform.CompareTag("Table") && currentItemHeld != null)
            {
                Debug.Log("Put on table");
            }
            //add another else if item is trash and currentitemheld != null
                //Debug.Log("Trash Item");
        }
    }

    private void PickupItem(Transform item)
    {
        item.parent = this.gameObject.transform;
        item.localPosition = new Vector2(0.75f, -0.75f);
        currentItemHeld = item.gameObject;
    }
    private void DropItem()
    {
        currentItemHeld.transform.parent = null;
        currentItemHeld = null;
    }

    private void TrashItem(Collision item)
    {
        if (item.gameObject.name == "TrashBin")
        {
            Destroy(item.gameObject);
        }
    }
    #endregion
}
