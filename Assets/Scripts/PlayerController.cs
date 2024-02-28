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
    #endregion

    #region Unity Functions
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }

    void Update()
    {
        Move();
    }
    #endregion

    #region User Functions

    /* Make player move */
    void Move() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(inputX, inputY);
        rb.velocity = moveDirection * moveSpeed;
    }
    #endregion
}
