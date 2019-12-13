using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState PlayerState;
    public float Speed;
    private Rigidbody2D Player;
    private Vector3 Change;
    private Animator Animator;
    public FloatValue Health;
    public SignalEvent PlayerHealthSignal;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState = PlayerState.walk;
        Player = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Animator.SetFloat("MoveX", 0f);
        Animator.SetFloat("MoveY", -1f);

    }

    // Update is called once per frame
    void Update()
    {
        Change = Vector3.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && PlayerState != PlayerState.attack && PlayerState != PlayerState.stagger)
        {
            StartCoroutine(AttackCoroutine());
        } else if (PlayerState == PlayerState.walk || PlayerState == PlayerState.idle)
        {
            MoveAndAnimatePlayer();
        }
        
    }
    private void MoveAndAnimatePlayer()
    {
        if (Change != Vector3.zero)
        {
            PlayerState = PlayerState.walk;
            MovePlayer();
            Animator.SetFloat("MoveX", Change.x);
            Animator.SetFloat("MoveY", Change.y);
            Animator.SetBool("Moving", true);
        }
        else
        {
            PlayerState = PlayerState.idle;
            Animator.SetBool("Moving", false);
        }
    }

    private IEnumerator AttackCoroutine()
    {
        Animator.SetBool("Attacking", true);
        PlayerState = PlayerState.attack;
        yield return null;
        Animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.33f);
        PlayerState = PlayerState.walk;
    }

    void MovePlayer()
    {
        Change.Normalize();
        Player.MovePosition(
            transform.position + Change * Speed * Time.deltaTime
            );
    }

    public void Knockback(float knockbackTime, float damage)
    {
        Health.RuntimeValue -= damage;
        PlayerHealthSignal.Raise();
        if (Health.RuntimeValue > 0)
        {
            StartCoroutine(KnockbackTimeout(knockbackTime));
        }
        else
        {
            TextOverlayManager overlayManager = GameObject.FindWithTag("OverlayManager").GetComponent<TextOverlayManager>();
            StartCoroutine(overlayManager.DisplayTextOverlay("Game Over", 4f));
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator KnockbackTimeout(float knockbackTime)
    {
        if (Player != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            PlayerState = PlayerState.idle;
            Player.velocity = Vector2.zero;
        }
    }
}
