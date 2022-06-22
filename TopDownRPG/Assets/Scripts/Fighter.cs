using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Public fields
    public int hitPoint = 10;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed = 0.1f;

    // Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    // All fighters can ReceiveDamage / Death
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 16, Color.red, transform.position, Vector3.up * 50, .5f);

            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        Debug.Log("Death() was not implemented in " + this.name);
    }

}
