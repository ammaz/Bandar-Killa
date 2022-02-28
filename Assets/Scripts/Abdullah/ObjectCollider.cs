using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public ParticleSystem boom;
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
            transform.LookAt(other.gameObject.transform.position);
            anim.SetBool("IsAttack",true);
            Destroy(other.gameObject,1f);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsRunning",false);

            yield return new WaitForSeconds(2f);
            boom.Play();
            anim.SetBool("IsAttack",false);
            anim.SetBool("IsIdle",true);
            yield return null;
        }
    }
}
