using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public Transform obj_Dest;
    public Transform player;

    public float pickUpRange;

    void Update()
    {

        Vector3 distanceToPlayer = player.position - transform.position;

        if (Input.GetKeyDown(KeyCode.Z) && distanceToPlayer.magnitude < pickUpRange)
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = obj_Dest.position;
            this.transform.parent = GameObject.Find("Object_Hold").transform;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }

        
    }

}
