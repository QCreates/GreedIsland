using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    public Animator animator;
    float horizontalMove = 0f;
    float runSpeed = 40f;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update(){
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    private void FixedUpdate(){
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * 3 * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null){
            //Movement
            transform.Translate(0, moveDelta.y * Time.deltaTime * 3, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * 3 * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null){
            //Movement
            transform.Translate(moveDelta.x * Time.deltaTime * 3, 0, 0);
        }
    }

}
