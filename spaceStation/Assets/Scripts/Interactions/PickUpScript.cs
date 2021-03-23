using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Flaregun Objects;
    public Interact ItemName;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, LeftItemContainer, RightItemContainer, PlayerDrop, PassiveItemsContainer, UsedItems, fpsCam;
    public GameObject Item;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private string whatItem;

    // Start is called before the first frame update
    void Start()
    {
        //SetUp
        if (!equipped)
        {
            Objects.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            Objects.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //is player in range and E pressed?
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }
        //Drop if equipped and Q pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
        if (Item.transform.parent == UsedItems)
        {
            Used();
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make item child of itemContainer and move to default position
        transform.SetParent(RightItemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero); //may need to change
        transform.localScale = Vector3.one;

        //Make rigidbody kinematic and boxcollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        Objects.enabled = true;

        whatItem = Item.name;
        Debug.Log(whatItem);
        ItemName.WhatItem(whatItem);
        //Send item info to Interact

    }
    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(PassiveItemsContainer);

        //Make rigidbody kinematic and boxcollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of plaer
//        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        //rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        //rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        //float random = Random.Range(-1f, 1f);
        //rb.AddTorque(new Vector3(random, random, random) * 10);

        //disable script
        Objects.enabled = false;
        whatItem = "Get Item";
        Debug.Log(whatItem);
        ItemName.WhatItem(whatItem);
        //Send item info to Interact
    }

    private void Used()
    {
        equipped = false;
        slotFull = false;
        //Item.SetActive(false);
        Destroy(Item);
    }
}
