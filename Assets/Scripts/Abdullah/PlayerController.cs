using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerController : MonoBehaviour
{
    public Animator animation;
    //public Touch myTouch;
    //public Behaviour PlayerController1;
    private NavMeshAgent myNavMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            ClicktoMove();
        }
        
        /*if(animation.GetBool("IsAttack")){
            PlayerController1.enabled = false;
        }
        if(animation.GetBool("IsAttack")){
            Debug.Log("test");
            PlayerController1.enabled = true;
        }*/
    }

    private void ClicktoMove()
    {
        //myTouch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            SetDestination(hit.point);
            animation.SetBool("IsIdle", false);
            animation.SetBool("IsRunning", true);
            animation.SetBool("IsAttack", false);
        }
        else
        {
            animation.SetBool("IsIdle", true);
            animation.SetBool("IsRunning", false);
            animation.SetBool("IsAttack", false);
        }
    }

    private void SetDestination(Vector3 target)
    {
        myNavMeshAgent.SetDestination(target);
    }
}
