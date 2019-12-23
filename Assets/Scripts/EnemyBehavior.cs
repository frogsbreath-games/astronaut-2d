using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class EnemyBehavior : MonoBehaviour
{
    public EnemyState EnemyState;
    public float Health;
    public int BaseDamage;
    public string EnemyName;
    public float MovementSpeed;
    public FloatValue MaxHealth;
    public HealthBarManager HealthBarManager;

    IEnumerator KnockbackTimeout(Rigidbody2D rigidbody, float knockbackTime)
    {
        if (rigidbody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            EnemyState = EnemyState.idle;
            rigidbody.velocity = Vector2.zero;
        }
    }

    public void Knockback(Rigidbody2D rigidbody, float knockbackTime, float damage)
    {
        StartCoroutine(KnockbackTimeout(rigidbody, knockbackTime));
        RecieveDamage(damage);
    }

    public void RecieveDamage(float damage)
    {
        Health -= damage;
        HealthBarManager.SetHealthBarSize(Health / MaxHealth.InitialValue);

        if(Health/MaxHealth.InitialValue < .5f)
        {
            HealthBarManager.SetHealthBarColor(Color.red);
        }

        if(Health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
