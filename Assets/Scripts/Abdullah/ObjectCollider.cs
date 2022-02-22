using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsIdle",true);
        anim.SetBool("IsRunning",false);
        anim.SetBool("IsAttack",false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            anim.SetBool("IsAttack",true);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsRunning",false);

            yield return new WaitForSeconds(2f);
            anim.SetBool("IsAttack",false);
            anim.SetBool("IsIdle",true);
            yield return null;
            //Destroy(other.gameObject);
        }
    }
}
