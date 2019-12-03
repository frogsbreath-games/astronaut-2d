using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float Thrust;
    public float KnockbackTime;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hittable") && this.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<EggBehavior>().Burst();
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hitTarget = collision.GetComponent<Rigidbody2D>();
            if (hitTarget != null)
            {
                Vector2 difference = hitTarget.transform.position - transform.position;
                difference = difference.normalized * Thrust;
                hitTarget.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
                {
                    hitTarget.GetComponent<EnemyBehavior>().EnemyState = EnemyState.stagger;
                    collision.GetComponent<EnemyBehavior>().Knockback(hitTarget, KnockbackTime, Damage);
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    hitTarget.GetComponent<PlayerMovement>().PlayerState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knockback(KnockbackTime);
                }
                
            }
        }
    }

    IEnumerator KnockbackTimeout(Rigidbody2D rigidbody)
    {
        if (rigidbody != null)
        {
            yield return new WaitForSeconds(KnockbackTime);
            rigidbody.velocity = Vector2.zero;
        }
    }
}
