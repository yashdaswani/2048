using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using UnityEngine.UI;
using TMPro;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayFabs : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;
    public TMP_InputField UserDisplayName;
    public Text usersUsername;
    string LoggedInPlayfabId;
    public bool loggedIn = false;
    public static PlayFabs instance;
    public GameObject inputNamePanel;
    string leaderboardName = "MergingScore";
    int highscoreValToSend = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highscoreValToSend = PlayerPrefs.GetInt("HighScore", 0);
        Login();
        if (!PlayerPrefs.HasKey("myName"))
        {
            inputNamePanel.SetActive(true);
        }
        PlayerPrefs.SetString("displayName", PlayerPrefs.GetString("myName"));
        Invoke("sendHighscore", 3f);

    }
    public void SaveNewNameUser()
    {
        if (UserDisplayName.text != "")
        {
            PlayerPrefs.SetString("myName", UserDisplayName.text);
            updateName();
        }
        else
        {
            PlayerPrefs.SetString("myName", "UnknownPlayer");
            updateName();
        }
        inputNamePanel.SetActive(false);
    }

    void updateName()
    {
        PlayerPrefs.SetString("displayName", PlayerPrefs.GetString("myName"));
        OnUpdatePlayerName();
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void showLeaderBoard(GameObject leaderBoard)
    {
        leaderBoard.SetActive(true);
    }
    public void closeLeaderboard(GameObject Leaderboard)
    {
        Leaderboard.SetActive(false);
    }
    void sendHighscore()
    {
        SendLeaderboard(highscoreValToSend);
    }

    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        loggedIn = true;
        updateName();
        LoggedInPlayfabId = result.PlayFabId;
        PlayerPrefs.SetString("loginStatus", "Logged in Successfully");
        Debug.Log("successfully logged in with custom id");
    }

    void lateLogin()
    {
        Login();
    }
    void OnError(PlayFabError error)
    {
        loggedIn = false;
        PlayerPrefs.SetString("loginStatus", "Log in failed due to network error");
        Debug.Log("failed to logged in with custom id");
    }
    void OnError2(PlayFabError error)
    {
        Debug.Log("failed to send or retrieve leaderboard");
    }
    public void SendLeaderboard(int Highscore)
    {

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = leaderboardName,
                    Value = (int)Highscore
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError2);
    }
    public void GetLeaderboard()
    {
        Invoke("sendHighscore", 0f);
        var request = new GetLeaderboardRequest
        {
            StatisticName = leaderboardName,
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError2);
    }

    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        int i = 0;
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {

            //instaUsername[i] = item.DisplayName;
            i++;
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            if (item.Position == 0)
            {
                PlayerPrefs.SetInt("rankOneLevels", item.StatValue);
                texts[1].text = item.DisplayName;
            }
            else if (item.Position == 1)
            {
                texts[1].text = item.DisplayName;
            }
            else if (item.Position == 2)
            {
                texts[1].text = item.DisplayName;
            }
            else
            {
                texts[1].text = item.DisplayName;
            }



            if (item.StatValue < 10000)
            {
                texts[2].text = item.StatValue.ToString("0");
            }
            else if (item.StatValue >= 10000 && item.StatValue < 1000000)
            {
                texts[2].text = ((float)(item.StatValue) / (1000)).ToString("F1") + "K";
            }
            else if (item.StatValue >= 1000000 && item.StatValue < 100000000)
            {
                texts[2].text = ((float)(item.StatValue) / (1000000)).ToString("F1") + "M";
            }
            
            else
            {
                texts[2].text = item.StatValue.ToString("0");
            }
        }
    }
    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = leaderboardName,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError2);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        int i = 0;
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {

            //instaUsername[i] = item.DisplayName;
            i++;
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;

            if (item.StatValue < 10000)
            {
                texts[2].text = item.StatValue.ToString("0");
            }
            else if (item.StatValue >= 10000 && item.StatValue < 1000000)
            {
                texts[2].text = ((float)(item.StatValue) / (1000)).ToString("F1") + "k";
            }
            else if (item.StatValue >= 1000000 && item.StatValue < 100000000)
            {
                texts[2].text = ((float)(item.StatValue) / (1000000)).ToString("F1") + "M";
            }
            else
            {
                texts[2].text = item.StatValue.ToString("0");
            }

            if (item.PlayFabId == LoggedInPlayfabId)
            {
                PlayerPrefs.SetInt("myRank", item.Position + 1);
                texts[1].color = Color.white;
            }
        }
    }

    public void OnUpdatePlayerName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = PlayerPrefs.GetString("displayName")

        }, result =>
        {
            Debug.Log("The player's display name is now: " + result.DisplayName);
        }, error => OnUpdatePlayerName()); ;
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("successfully sent highscore");
    }
}
