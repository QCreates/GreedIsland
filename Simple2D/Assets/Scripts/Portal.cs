using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Portal : Collidable {

    Player player;

    void Start(){
        player = gameObject.GetComponent<Player>();
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player_0")
        {
           StartCoroutine("Teleport");
        }
    }

    IEnumerator Teleport(){
        player.AllowPlayerMovement = false;
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector2(16f, 8f);
        yield return new WaitForSeconds(1f);
        player.AllowPlayerMovement = true;    
    }
}