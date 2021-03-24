using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Console_Click : MonoBehaviour
{
    public Transform[] obj;
    public GameObject player;

    public bool chip_Complete = false;
    public bool can_Complete = false;
    public bool blue_ATM_complete = false;
    public bool green_ATM_complete = false;

    public int CanNumber;
    public int BlueCellNumber;
    public int GreenCellNumber;

    private int state;
    private int can_Count;
    private int blue_ATM_count;
    private int green_ATM_count;

    private void Start()
    {
        can_Count = 0;
        blue_ATM_count = 0;
        green_ATM_count = 0;
    }
    void Update()
    {

        state = 0;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    obj = GetComponentsInChildren<Transform>(true);
                    foreach (var ob in obj.Where(ob => (ob != transform)))
                    {
                        if (hit.collider.gameObject.name == "Console" && ob.name == "Chip") state = 1;
                        if (hit.collider.gameObject.name == "Shuttle" && ob.name == "Can") state = 2;
                        if (hit.collider.gameObject.name == "ATM_Blue" && ob.name == "cell_Blue") state = 3;
                        if (hit.collider.gameObject.name == "ATM_Green" && ob.name == "cell_Green") state = 4;
                    }

                    int numChildren = player.transform.childCount;

                    if (state > 0)
                    {
                        //int numChildren = player.transform.childCount;
                        Destroy(player.transform.GetChild(numChildren - 1).gameObject);
                    }

                    switch (state)
                    {
                        case 1: 
                            Chip();
                        break;
                        case 2:
                            Can();
                        break;
                        case 3:
                            cell_Blue();
                        break;
                        case 4:
                            cell_Green();
                            break;
                        default:
                            if (numChildren > 0) Debug.Log("Wrong Item");
                            else Debug.Log("No Item");
                        break;
                    }   
                }            
            }
                           
        }

        if(chip_Complete == true && can_Complete == true && blue_ATM_complete == true && green_ATM_complete == true)
        {
            Debug.Log("You Win!");
        }

    }
        
    //-------------------------------------------------------------------------------//

    private void Chip()
    {
        chip_Complete = true;
        Debug.Log("Chip Destroyed");
    }
    private void Can()
    {
        can_Count++;
        if(can_Count == CanNumber)
        {
            can_Complete = true;
            can_Count = 0;
        }
        Debug.Log("Can Destroyed");
    }
    private void cell_Blue()
    {
        blue_ATM_count++;
        if(blue_ATM_count == BlueCellNumber)
        {
            blue_ATM_complete = true;
            blue_ATM_count = 0;
        }
        Debug.Log("Blue Cell Destroyed");
    }

    private void cell_Green()
    {
        green_ATM_count++;
        if(green_ATM_count == GreenCellNumber)
        {
            green_ATM_complete = true;
            green_ATM_count = 0;
        }
        Debug.Log("Green Cell Destroyed");
    }

}
