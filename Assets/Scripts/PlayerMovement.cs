using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Player;
    private Vector3 Change;
    private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Change = Vector3.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        if(Change != Vector3.zero)
        {
            MovePlayer();
            Animator.SetFloat("MoveX", Change.x);
            Animator.SetFloat("MoveY", Change.y);
            Animator.SetBool("Moving", true);
        } else
        {
            Animator.SetBool("Moving", false);
        }
    }

    void MovePlayer()
    {
        Player.MovePosition(
            transform.position + Change * Speed * Time.deltaTime
            );
    }
}
