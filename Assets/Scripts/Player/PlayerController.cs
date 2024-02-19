using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Move Params
    float Xpos;
    // Jump and Crouch Params
    public bool CanJump = false;
    Rigidbody Rigidbody;
    CapsuleCollider CapsuleCollider;
    public LayerMask GroundLayer;
    //Anim Params
    Animator Animator;
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
        Animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
            Xpos = Mathf.Clamp(Xpos, -2, 2);
            Vector3 Pos = new Vector3(Xpos, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Pos, 0.1f);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Xpos += 2;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Xpos -= 2;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Crouch();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump)
            {
                Jump();
            }
            Animator.SetBool("IsGrounded", !CanJump);
        }
        void Jump()
        {

            Rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        void Crouch()
        {
            Animator.SetTrigger("Crouch");
            CapsuleCollider.height = 0;
            Invoke(nameof(ResetCrouch), 1f);
        }
        void ResetCrouch()
        {
            CapsuleCollider.height = 2;
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                CanJump = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                CanJump = false;
            }
        }
}
