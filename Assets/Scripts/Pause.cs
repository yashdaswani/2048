using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject resumepnl;
    

    public void pausebutton()
    {
        Blocks.checktouch = false;
        resumepnl.SetActive(true);
        Time.timeScale = 0f;
    }


    public void resumebutton()
    {
        Blocks.checktouch = true;
        resumepnl.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitgame()
    {
        Application.Quit();
    }
    
}
