using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    public Animator animator;
    float horizontalMove = 0f;
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = .75f;
    protected float xSpeed = 1.0f;

    protected virtual void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update(){
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
    }

    protected virtual void UpdateMotor(Vector3 input){

        // Reset MoveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //Reduce push force every frame, based off recover speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

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
