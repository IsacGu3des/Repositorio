using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public Text scoreText;
    public GameObject gameOver;

    public static GameController instace;
    // Start is called before the first frame update
    void Start()
    {
        instace = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = TotalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        
    }

    public void RestartGame(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }
    
}
