using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float Thrust;
    public float KnockbackTime;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * Thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockbackTimeout(enemy));
            }
        }
    }

    IEnumerator KnockbackTimeout(Rigidbody2D rigidbody)
    {
        if (rigidbody != null)
        {
            yield return new WaitForSeconds(KnockbackTime);
            rigidbody.velocity = Vector2.zero;
            rigidbody.isKinematic = true;
        }
    }
}
