using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
    public Sprite emptyChest;
    public int cashAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + cashAmount + "$", 16, new Color(0.4766056f, 0.8207547f, 0.367791f, 1.0f), transform.position, Vector3.up * 50, 2.0f);
        }
    }
}
