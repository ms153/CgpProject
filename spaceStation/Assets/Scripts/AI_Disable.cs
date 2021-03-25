using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Disable : MonoBehaviour
{
    public GameObject enemy;
    private FieldOfView enable;
    // Update is called once per frame

    private bool shot;

    private void Start()
    {
        enable = enemy.GetComponent<FieldOfView>();
        shot = true;
    }

    void Update()
    {
        //*----Shot fired-------------*
        //when gun is shot and shot count equals 0
        

        
        if (Input.GetKeyDown(KeyCode.Mouse0) && shot == true)
        {
            enable.AI_Enable = false;
            StartCoroutine("delayEnemy", .2f);
            
        }

        

    }

    
    IEnumerator delayEnemy(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            enable.AI_Enable = false;
            Debug.Log("Enemy paused for 2 seconds");
            resume();
        }
 
    }
    

    public void disableMovement()
    {
        enable.AI_Enable = false;
    }

    public void enableMovement()
    {
        enable.AI_Enable = true;
    }

    public void resume()
    {
        Debug.Log("Enabling movement again");
        enable.AI_Enable = true;
        shot = false;
    }
}
