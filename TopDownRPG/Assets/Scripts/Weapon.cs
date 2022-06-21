using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collideable
{
    // Damage structure
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private float coolDown = 0.5f;
    private float lastSwing;


    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            Debug.Log(coll.name);
        }
    }

    private void Swing()
    {
        Debug.Log("s'Winging it!");
    }
}
