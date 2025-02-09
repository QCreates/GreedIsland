using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{ 
    //Experience
    public int xpValue = 1;

    //Logic
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    private void FixedUpdate(){
        //Check for overlap
        collidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits);
        for(int i = 0; i < hits.Length; i++){
            if(hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player"){
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
    }

    protected override void Death(){
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }

}

