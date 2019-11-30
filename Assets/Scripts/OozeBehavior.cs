using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozeBehavior : EnemyBehavior
{
    public Rigidbody2D Rigidbody2D;
    public Transform Target;
    public float ChaseRadius;
    public float AttackRadius;
    public Transform HomePosition;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        EnemyState = EnemyState.idle;
        Target = GameObject.FindWithTag("Player").transform;
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(Target.position
            , transform.position) <= ChaseRadius 
            && Vector3.Distance(Target.position
            , transform.position) > AttackRadius)
        {
            if ((EnemyState == EnemyState.idle || EnemyState == EnemyState.walk) && EnemyState != EnemyState.stagger    )
            {
                ChangeState(EnemyState.walk);
                Animator.SetBool("Alert", true);
                Vector3 tempPosition = Vector3.MoveTowards(transform.position, Target.position, MovementSpeed * Time.deltaTime);
                Rigidbody2D.MovePosition(tempPosition);
            }
        } else
        {
            Animator.SetBool("Alert", false);
        }
    }

    void ChangeState(EnemyState state)
    {
        if(EnemyState != state)
        {
            EnemyState = state;
        }
    }
}
