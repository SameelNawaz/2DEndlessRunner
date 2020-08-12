using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}
    private int _score = 0;
    private int _highScore = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore",0);

        UIManager.Instance.UpdateHighScoreText(_highScore.ToString());
        UIManager.Instance.UpdateScoreText(_score.ToString());
    }

    public void UpdateScore(int amount)
    {
        _score += amount;
        UIManager.Instance.UpdateScoreText(_score.ToString());
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            UIManager.Instance.UpdateHighScoreText(_highScore.ToString());
        }
    }
}
