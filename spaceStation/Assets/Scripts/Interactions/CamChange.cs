using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject Cam1; //assign to camera 1 in editor
    public GameObject Cam2; //camera 2
    public GameObject Cam3;//camera 3
    public GameObject Cam4;//camera 4
    public GameObject FpsCam;//camera 5
    public GameObject CameraControl;


    private void OnEnable()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        Cam4.SetActive(false);
        FpsCam.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) //show camera 1
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Cam4.SetActive(false);
            FpsCam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //show camera 2
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            Cam3.SetActive(false);
            Cam4.SetActive(false);
            FpsCam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //show camera 3
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(true);
            Cam4.SetActive(false);
            FpsCam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) //show camera 4
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Cam4.SetActive(true);
            FpsCam.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Cam4.SetActive(false);
            FpsCam.SetActive(true);
            CameraControl.SetActive(false);
        }

    }
}
