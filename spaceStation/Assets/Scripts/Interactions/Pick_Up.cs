using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pick_Up : MonoBehaviour
{
    public Transform obj_Dest;
    public Transform player;
    //public GameObject ZText;

    public float pickUpRange;
   // private bool LookForItem;

    private void Start()
    {
        //ZText.SetActive(false);
    }

    void Update()
    {

        Vector3 distanceToPlayer = player.position - transform.position;

        /*if(distanceToPlayer.magnitude < pickUpRange && LookForItem == false)
        {
            //Debug.Log("Hovered Over");
            ZText.SetActive(true);
            LookForItem = true;
        }
        else if (distanceToPlayer.magnitude > pickUpRange && LookForItem == true)
        {
            //Debug.Log("Not Hovered Over");
            ZText.SetActive(false);
            LookForItem = false;
        }*/

        if (Input.GetKeyDown(KeyCode.Z) && distanceToPlayer.magnitude < pickUpRange)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            this.transform.position = obj_Dest.position;
            this.transform.parent = GameObject.Find("Object_Hold").transform;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }


    }
}
