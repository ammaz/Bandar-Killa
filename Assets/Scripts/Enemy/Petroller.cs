using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Petroller : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    private int waypointIndex;
    private float dist;
    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    public static void EnemeyGotoSandal(GameObject Tes)
    {
        Tes.transform.LookAt(Attack.SelectedSandal.transform.position);
        //Here "2" is speed
        Tes.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        /*if (Vector3.Distance(Tes.transform.position, Attack.SelectedSandal.transform.position) < 1f)
        {
            Tes.transform.Rotate(0, 0, 0);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sandal")
        {
            GameObject ToBePickedSandal = collision.gameObject;
            this.gameObject.transform.LookAt(waypoints[waypointIndex].position);

            //PickWeapon
            ToBePickedSandal.transform.position = Hand.transform.position;
            ToBePickedSandal.transform.parent = Hand.transform;
            //ToBePickedSandal.GetComponent<BoxCollider>().isTrigger = true;
            //ToBePickedSandal.GetComponent<Rigidbody>().isKinematic=true;

            //Destroying Picked Sandal
            Destroy(ToBePickedSandal, 2f);
        }
    }
}
