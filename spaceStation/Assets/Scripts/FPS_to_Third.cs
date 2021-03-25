using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_to_Third : MonoBehaviour
{
    public Transform FPS;
    public Transform Third;
    public Camera MainCam;

    private bool SwapFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        MainCam.transform.parent = Third;
        MainCam.transform.position = Third.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T");
            if(SwapFirst == true)
            {
                Debug.Log("First");
                MainCam.transform.parent = FPS;
                MainCam.transform.position = FPS.position;
                SwapFirst = false;
            }
            else
            {
                Debug.Log("Third");
                MainCam.transform.parent = Third;
                MainCam.transform.position = Third.position;
                SwapFirst = true;
            }
        }
    }
}
