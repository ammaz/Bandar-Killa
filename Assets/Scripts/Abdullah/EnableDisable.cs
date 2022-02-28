using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public Animator animation;
    public Behaviour PlayerController1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animation.GetBool("IsAttack")){
            PlayerController1.enabled = false;
        }
        if(animation.GetBool("IsAttack")){
            PlayerController1.enabled = true;
        }
    }
}
