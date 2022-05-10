using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Public fields
    public int hitpoint;
    public int maxHitpoint;
    public float pushRecoverySpeed = 0.2f;

    //Imunity
    protected float ImmuneTime = 1.0f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    // All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > ImmuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.showText(dmg.damageAmount.ToString(), 25, Color.red, transform == ImagePosition, Vector3.zero 0.5f);

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }
    protected virtual void Death()
    {

    }
}

//3hr, 40min