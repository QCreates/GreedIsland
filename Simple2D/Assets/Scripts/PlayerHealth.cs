using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    //starting health
   private float health = 0f;
   [SerializeField] private float maxHealth = 100f;

   private void Start() {
       //Creating starting Health
       health = maxHealth;
   }

   public void UpdateHealth(float mod) {
       health += mod;

        //if health is added, it won't go past the max health
        if (health > maxHealth) {
            health = maxHealth;
       } else if (health <= 0f) {
            health = 0f;
            Debug.Log("Player Respawn");
       }
   }
}
