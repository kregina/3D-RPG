using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    private readonly int FORWARD_SPEED_HASH = Animator.StringToHash("forwardSpeed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    MoveToCursor();
        //}

        UpdateAnimator();
    }

    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }   

    private void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat(FORWARD_SPEED_HASH, speed);
    }
}
