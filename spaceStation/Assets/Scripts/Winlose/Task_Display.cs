using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_Display : MonoBehaviour
{
   // public Transform Pos1, pos2, Pos3, Pos4;
    public GameObject Task1, Task2, Task3, Task4;
    static int TaskCompleted;

    // Start is called before the first frame update
    void Start()
    {
        Task1.SetActive(true);
        Task2.SetActive(true);
        Task3.SetActive(true);
        Task4.SetActive(true);
    }

    

    // Update is called once per frame
    void Update()
    {
        TaskCompleted = Click_Interact.RemoveTask;
        if (TaskCompleted == 1)
        {
            Task1.SetActive(false);
        }
        if (TaskCompleted == 2)
        {
            Task2.SetActive(false);
        }
        if (TaskCompleted == 3)
        {
            Task3.SetActive(false);
        }
        if (TaskCompleted == 4)
        {
            Task4.SetActive(false);
        }
    }
}
