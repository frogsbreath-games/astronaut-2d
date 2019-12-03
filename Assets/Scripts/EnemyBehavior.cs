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
    public float BaseHealth;
    public int BaseDamage;
    public string EnemyName;
    public float MovementSpeed;
    public FloatValue MaxHealth;

    IEnumerator KnockbackTimeout(Rigidbody2D rigidbody, float knockbackTime)
    {
        if (rigidbody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            EnemyState = EnemyState.idle;
            rigidbody.velocity = Vector2.zero;
        }
    }

    public void Knockback(Rigidbody2D rigidbody, float knockbackTime)
    {
        StartCoroutine(KnockbackTimeout(rigidbody, knockbackTime));
    }
}
