using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozeBehavior : EnemyBehavior
{
    public Transform Target;
    public float ChaseRadius;
    public float AttackRadius;
    public Transform HomePosition;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
            Animator.SetBool("Alert", true);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, MovementSpeed * Time.deltaTime);
        } else
        {
            Animator.SetBool("Alert", false);
        }
    }
}
