using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {

    #region Variables
    //Public
    public bool gameStarted = false;
    //Private



    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private int score;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button shopButton;
    [SerializeField]
    private Button leaderBoardButton;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Button tapToPlayButton;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private Button facebookButton;
    [SerializeField]
    private Button achievementsButton;
    [SerializeField]
    private Text endScoreText;
    [SerializeField]
    private Text endBestScoreText;
    private bool onOff;


    #endregion

    // Use this for initialization
    void Start () {
        Debug.Log(PlayerPrefs.GetInt("Score"));
        gameStarted = false;
        InvokeRepeating("UpdateScore", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SettingsFunctions()
    {

    }

    public void ShopFunctions()
    {

    }

    public void MuteGame()
    {
        
        onOff = !onOff;
        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            AudioListener.volume = 100;
        }
        else
        {
            AudioListener.volume = 0;
        }


        if(onOff == true)
        {
            PlayerPrefs.SetInt("Audio", 0);
            AudioListener.volume = 100;
        }
        else
        {
            PlayerPrefs.SetInt("Audio", 1);
            AudioListener.volume = 0;
        }
        Debug.Log(AudioListener.volume);
        PlayerPrefs.Save();
    }

    public void PlayGame()
    {

        facebookButton.gameObject.SetActive(false);
        achievementsButton.gameObject.SetActive(false);
        endScoreText.gameObject.SetActive(false); // disable menu score texts

        endBestScoreText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true); // enable ingame score text

        settingsButton.gameObject.SetActive(false);  // disable buttons
        shopButton.gameObject.SetActive(false);
        leaderBoardButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        tapToPlayButton.gameObject.SetActive(false);
        gameStarted = true;
    }

    private void UpdateScore()
    {
        if(gameStarted == true)
        {
            score++;
            scoreText.text = "" + score;
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameEnded()
    {
        if (PlayerPrefs.GetInt("Score") < score)
        {
            PlayerPrefs.SetInt("Score", score); // New Highscore
        }
        PlayerPrefs.Save();
        endScoreText.text = "Score:         " + score;
        endBestScoreText.text = "Best Score:        " + PlayerPrefs.GetInt("Score");
        endScoreText.gameObject.SetActive(true); // enable menu score text
        endBestScoreText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true); // Enables menu button
        homeButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false); // disable ingame score text
        
    }
}
