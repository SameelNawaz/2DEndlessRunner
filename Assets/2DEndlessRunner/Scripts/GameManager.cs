using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool _isGameOver;
    private bool _startGame;
    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        UIManager.Instance.AssignText("Press 'R' To Restart");
        _isGameOver = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_startGame)
        {
            _startGame = true;
            UIManager.Instance.AssignText("");
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    public bool IsGameOver()
    {
        return _isGameOver;
    }
    public bool IsGameStarted()
    {
        return _startGame;
    }
}
