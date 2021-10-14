using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Level level;

    public GameOver gameOver;

    public Text remainingText;
    public Text remainingSubText;

    public Text targetText;
    public Text targetSubText;

    public Text scoreText;
    public Image[] stars;

    private int starIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<stars.Length; i++)
        {
            if (i == starIdx)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();

        int visibleStar = 0;

        if(score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if(score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }else if(score >= level.score3Star)
        {
            visibleStar = 3;
        }

        for (int i = 0; i < stars.Length; i++)
        {
            if (i == visibleStar)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }

        starIdx = visibleStar;
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }

    public void SetlevelType(Level.LevelType type)
    {
        if(type == Level.LevelType.MOVES)
        {
            remainingSubText.text = "Moves remaining";
            targetSubText.text = "target Score";
            return;
        }

        if (type == Level.LevelType.OBSTACLE)
        {
            remainingSubText.text = "Moves remaining";
            targetSubText.text = "Rock remaining";
            return;
        }

        if (type == Level.LevelType.TIMER)
        {
            remainingSubText.text = "Time remaining";
            targetSubText.text = "target Score";
            return;
        }
    }

    public void OnGameWin(int score)
    {
        gameOver.ShowWin(score, starIdx);
        if (starIdx > PlayerPrefs.GetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, starIdx);
        }
    }

    public void OnGameLose()
    {
        gameOver.ShowLose();
    }

    public void BackToSelectLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("levelSelect");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
