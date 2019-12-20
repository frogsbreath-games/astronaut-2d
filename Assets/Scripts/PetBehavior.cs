using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PetState
{
    idle,
    walk,
    attack
}

public class PetBehavior : MonoBehaviour
{

    public Rigidbody2D Rigidbody2D;
    public Transform Target;
    public float ChaseRadius;
    public float AttackRadius;
    public Transform HomePosition;
    private Animator Animator;
    private PetState PetState;
    public float MovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        PetState = PetState.idle;
        Target = GameObject.FindWithTag("Player").transform;
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(Target.position
            , transform.position) <= ChaseRadius
            && Vector3.Distance(Target.position
            , transform.position) > AttackRadius)
        {
            if (PetState == PetState.idle || PetState == PetState.walk)
            {
                ChangeState(PetState.walk);
                Animator.SetBool("Moving", true);
                Vector3 tempPosition = Vector3.MoveTowards(transform.position, Target.position, MovementSpeed * Time.deltaTime);
                ChangeAnimation(tempPosition - Target.position);
                Rigidbody2D.MovePosition(tempPosition);
            }
        }
        else if (Vector3.Distance(Target.position
          , transform.position) > ChaseRadius || Vector3.Distance(Target.position
          , transform.position) < AttackRadius)
        {
            Animator.SetBool("Moving", false);
            Rigidbody2D.velocity = Vector3.zero;
        }
    }

    private void ChangeAnimation(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimationFloat(Vector2.left);
            }
            else if (direction.x < 0)
            {
                SetAnimationFloat(Vector2.right);

            }
        }
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            if (direction.y > 0)
            {
                SetAnimationFloat(Vector2.down);

            }
            else if (direction.y < 0)
            {
                SetAnimationFloat(Vector2.up);
            }
        }
    }

    private void SetAnimationFloat(Vector2 direction)
    {
        Animator.SetFloat("MoveX", direction.x);
        Animator.SetFloat("MoveY", direction.y);
    }

    void ChangeState(PetState state)
    {
        if (PetState != state)
        {
            PetState = state;
        }
    }
}
