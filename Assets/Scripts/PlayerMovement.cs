using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    
    public float moveSpeed = 8f;
    public float jumpForce = 26f;
    private bool isGrounded;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        // movement
        float moveInput = Input.GetAxis("Horizontal");
        animator.SetInteger("XaxisRaw", (int)Input.GetAxisRaw("Horizontal"));
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // jump
        if(Input.GetButtonDown("Jump") && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.Instance.PlayAudio("jump");
        }
    }

    //ground check
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
        }
    }

}
