using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Disable : MonoBehaviour
{
    public GameObject enemy;
    private FieldOfView enable;
    // Update is called once per frame

    private void Start()
    {
        enable = enemy.GetComponent<FieldOfView>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            enable.AI_Enable = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            enable.AI_Enable = true;
        }
    }
}
