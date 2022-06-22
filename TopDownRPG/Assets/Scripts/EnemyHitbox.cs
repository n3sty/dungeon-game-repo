using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collideable
{
    // Damage
    public int damage = 1;
    public float pushForce = 3.0f;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            // Create a new damage object before sending it to the player
            Damage dmg = new()
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
