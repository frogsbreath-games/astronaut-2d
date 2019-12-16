using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
    }

    // Update is called once per frame Last
    void LateUpdate()
    {
        if(transform.position != Target.position)
        {
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Speed);
        }
    }
}
