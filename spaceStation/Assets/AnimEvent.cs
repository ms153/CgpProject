using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimEvent : MonoBehaviour
{
    public void endAnimation(string message)
    {
        if (message.Equals("YouHaveDied"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
