using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    public GameObject LeaderBoard;
    public GameObject usernamechange;
    public GameObject inputpanel;
    public AdsManager ads;


    void backButton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {

                //if (SceneManager.GetActiveScene().buildIndex == 3)

                //{
                //    SceneManager.LoadScene("mode");
                //}

                if (SceneManager.GetActiveScene().buildIndex == 2)

                {
                    SceneManager.LoadScene("menublock");
                }
                if (SceneManager.GetActiveScene().buildIndex == 1)

                {
                    SceneManager.LoadScene("menublock");
                }

                //if (SceneManager.GetActiveScene().buildIndex == 4)

                //{
                //    SceneManager.LoadScene("mode");
                //}

                // Insert Code Here (I.E. Load Scene, Etc)
                // OR Application.Quit();

                return;
            }
        }
    }

    //public void Start()
    //{
    //    ads.Banner();
    //}

    public void StartGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1) /*|| SceneManager.GetActiveScene().buildIndex == 2*/
        {
            PlayerPrefs.SetInt("myScene", SceneManager.GetActiveScene().buildIndex);
        }
        
        SceneManager.LoadScene(1);
    }


    public void openLeaderBoard()
    {
        LeaderBoard.SetActive(true);
    }

    public void closeLeaderBoard()
    {
        LeaderBoard.SetActive(false);
    }

    public void enterbutton()
    {
        inputpanel.SetActive(false);
    }
    public void instaopen()
    {
        usernamechange.SetActive(true);
    }

    public void yeschange()
    {

        usernamechange.SetActive(false);
        inputpanel.SetActive(true);
    }
    public void nochange()
    {
        usernamechange.SetActive(false);
    }

    public void TimeMode()
    {
        SceneManager.LoadScene(1);
    }

    //public void TimeFreeMode()
    //{
    //    SceneManager.LoadScene(2);
    //}

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void loadPrevScene()
    {
        //int sceneIndex = PlayerPrefs.GetInt("myScene");
        //SceneManager.LoadScene(sceneIndex);

        SceneManager.LoadScene(0);

    }
    public void Update()
    {
        backButton();
    }

    public void checkupdate()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.DegenerationX.MergeNumbers");
    }

    public void screenshot()
    {
        screensjo.takescreenshotstatic(500, 500);
    }


}


