using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerController : MonoBehaviour
{
    public Animator animation;
    public Touch myTouch;
    private NavMeshAgent myNavMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            ClicktoMove();
        }
        animation.SetFloat("Speed", myNavMeshAgent.velocity.magnitude);
    }

    private void ClicktoMove()
    {
        myTouch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(myTouch.position);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            SetDestination(hit.point);
            animation.SetBool("IsIdle", false);
            animation.SetBool("IsRunning", true);
            animation.SetBool("IsAttack", false);
        }
    }

    private void SetDestination(Vector3 target)
    {
        myNavMeshAgent.SetDestination(target);
    }
}
