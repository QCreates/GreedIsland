using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int bootyAmount = 5;

    protected override void OnCollect()
    {
        if (!collected){
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant" + bootyAmount + "booty!");
        }
    }
}
