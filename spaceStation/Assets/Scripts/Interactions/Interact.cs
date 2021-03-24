using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public float range = 4f;
    public GameObject playerray; //changed from camera

    public Transform UsedItems;

    private bool GotFlare = true;
    private bool GotItem1 = false;
    private bool GotItem2 = false;
    private bool GotItem3 = false;
    private bool GotItem4 = false;
    private bool GotItem5 = false;
    private bool GotItem6 = false;
    private bool GotItem7 = false;
    private bool GotItem8 = false;

    public GameObject SecurityMonitor;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;

    public GameObject Task1;
    public GameObject Task2;
    public GameObject Task3;
    public GameObject Task4;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;
    public GameObject Item7;
    public GameObject Item8;

    private float TaskCount = 0;
    private float Task2Count = 0;
    private float Task3Count = 0;
    private float Task4Count = 0;



    public GameObject CameraControl;


    // Start is called before the first frame update
    void Start()
    {
        playerray.SetActive(true);
        Cam1.SetActive(false);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        Cam4.SetActive(false);

        CameraControl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //from input manager
        {
            InteractRange(); //call function
        }
    }

    public void WhatItem(string ItemName)
    {
        Debug.Log("Interact" + ItemName);
        if(ItemName == Item1.name)
        {
            GotItem1 = true;
            GotItem2 = false;
            GotItem3 = false;
            GotItem4 = false;
            GotItem5 = false;
            GotItem6 = false;
            GotItem7 = false;
            GotItem8 = false;
            Debug.Log("Got item 1");
        }
        if (ItemName == Item2.name)
        {
            GotItem1 = false;
            GotItem2 = true;
            GotItem3 = false;
            GotItem4 = false;
            GotItem5 = false;
            GotItem6 = false;
            GotItem7 = false;
            GotItem8 = false;
            Debug.Log("Got item 2");

        }
        if (ItemName == Item3.name)
        {
            GotItem1 = false;
            GotItem2 = false;
            GotItem3 = true;
            GotItem4 = false;
            GotItem5 = false;
            GotItem6 = false;
            GotItem7 = false;
            GotItem8 = false;
            Debug.Log("Got item 3");

        }
        if (ItemName == Item4.name)
        {
            GotItem1 = false;
            GotItem2 = false;
            GotItem3 = false;
            GotItem4 = true;
            GotItem5 = false;
            GotItem6 = false;
            GotItem7 = false;
            GotItem8 = false;
            Debug.Log("Got item 4");

        }
        if (ItemName == Item5.name)
        {
            GotItem1 = false;
            GotItem2 = false;
            GotItem3 = false;
            GotItem4 = false;
            GotItem5 = true;
            GotItem6 = false;
            GotItem7 = false;
            GotItem8 = false;
            Debug.Log("Got item 5");

        }
        if (ItemName == Item6.name)
        {
            GotItem1 = false;
            GotItem2 = false;
            GotItem3 = false;
            GotItem4 = false;
            GotItem5 = false;
            GotItem6 = true;
            GotItem7 = false;
            GotItem8 = false;
            Debug.Log("Got item 6");

        }
        if (ItemName == Item7.name)
        {
            GotItem1 = false;
            GotItem2 = false;
            GotItem3 = false;
            GotItem4 = false;
            GotItem5 = false;
            GotItem6 = false;
            GotItem7 = true;
            GotItem8 = false;
            Debug.Log("Got item 7");

        }
        if (ItemName == Item8.name)
        {
            GotItem1 = false;
            GotItem2 = false;
            GotItem3 = false;
            GotItem4 = false;
            GotItem5 = false;
            GotItem6 = false;
            GotItem7 = false;
            GotItem8 = true;
            Debug.Log("Got item 8");

        }

    }
    public void InteractRange()
    {
        RaycastHit Hit;
        if (Physics.Raycast(playerray.transform.position, playerray.transform.forward, out Hit, range))
        {
            Debug.Log(Hit.transform.name);
            if (Hit.transform.name == SecurityMonitor.name)
            {
                Debug.Log("Begin Camera minigame");
                CameraControl.SetActive(true);
            }
            if (Hit.transform.name == Task1.name) //Task 1 = keycard
            {
                if (!GotItem1)
                {
                    Debug.Log("GetItem1");
                }
                else
                {
                    Debug.Log("Begin Item1 minigame");
                    //Move item to used items for hiding
                    Item1.transform.SetParent(UsedItems);
                    //Disable GotItem1
                    GotItem1 = false;
                    ++TaskCount;
                    Debug.Log("TaskCount = " + TaskCount);
                    if (TaskCount == 4)
                    {
                        Win();
                    }
                }
            }
            if (Hit.transform.name == Task2.name) //Task 2 = Green ATM
            {
                if (GotItem2 || GotItem3)
                {
                    Debug.Log("Begin Item2 minigame");
                    if (GotItem2)
                    {
                        //hide Item2
                        Item2.transform.SetParent(UsedItems);
                        //Disable GotItem2
                        GotItem2 = false;
                        ++Task2Count;
                        Debug.Log("TaskCount = " + TaskCount);
                        if (Task2Count == 2)
                        {
                            ++TaskCount;
                            if (TaskCount == 4)
                            {
                                Win();
                            }
                        }
                    }
                    if (GotItem3)
                    {
                        //hide Item3
                        Item3.transform.SetParent(UsedItems);
                        //Disable GotItem3
                        GotItem2 = false;
                        ++Task2Count;
                        Debug.Log("TaskCount = " + TaskCount);
                        if (Task2Count == 2)
                        {
                            ++TaskCount;
                            if (TaskCount == 4)
                            {
                                Win();
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("GetItem2");
                    //Disable GotItem2
                }
            }
            if (Hit.transform.name == Task3.name) //Task 3 = blue ATM
            {
                if (GotItem7 || GotItem8)
                {
                    Debug.Log("Begin Item3 minigame");
                    if (GotItem7)
                    {
                        //hide Item7
                        Item7.transform.SetParent(UsedItems);
                        //Disable GotItem7
                        GotItem7 = false;
                        ++Task3Count;
                        Debug.Log("TaskCount = " + TaskCount);
                        if (Task3Count == 2)
                        {
                            ++TaskCount;
                            if (TaskCount == 4)
                            {
                                Win();
                            }
                        }
                    }
                    if (GotItem8)
                    {
                        //hide Item8
                        Item8.transform.SetParent(UsedItems);
                        //Disable GotItem8
                        GotItem8 = false;
                        ++Task3Count;
                        Debug.Log("TaskCount = " + TaskCount);
                        if (Task3Count == 2)
                        {
                            ++TaskCount;
                            if (TaskCount == 4)
                            {
                                Win();
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("GetItem3");
                    //hide Item3
                    //Disable GotItem3
                }
            }
            if (Hit.transform.name == Task4.name) //Task 4 = Food
            {
                if (GotItem4 || GotItem5 || GotItem6)
                {
                    Debug.Log("Begin Item4 minigame");
                    if (GotItem4)
                    {
                        //hide Item4
                        Item4.transform.SetParent(UsedItems);
                        //Disable GotItem4
                        GotItem4 = false;
                        ++Task4Count;
                        Debug.Log("TaskCount = " + TaskCount);
                        if (Task4Count == 3)
                        {
                            ++TaskCount;
                            if (TaskCount == 4)
                            {
                                Win();
                            }
                        }
                    }
                    if (GotItem5)
                    {
                        //hide Item5
                        Item5.transform.SetParent(UsedItems);
                        //Disable GotItem5
                        GotItem5 = false;
                        ++Task4Count;
                        Debug.Log("TaskCount = " + TaskCount);
                        if (Task4Count == 3)
                        {
                            ++TaskCount;
                            if (TaskCount == 4)
                            {
                                Win();
                            }
                        }
                    }
                    if (GotItem6)
                    {
                        //hide Item6
                        Item6.transform.SetParent(UsedItems);
                        //Disable GotItem6
                        GotItem6 = false;
                        ++Task4Count;
                        Debug.Log("TaskCount = " + TaskCount);
                        if (Task4Count == 3)
                        {
                            ++TaskCount;
                            if (TaskCount == 4)
                            {
                                Win();
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("GetItem4");
                    //hide Item4
                    //Disable GotItem4
                }
            }
        }
    }
    private void Win()
    {
        Debug.Log("Win Game");
        SceneManager.LoadScene(3);
    }
}