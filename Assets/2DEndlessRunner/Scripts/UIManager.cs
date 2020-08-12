using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }

    [SerializeField] private TextMeshProUGUI m_MessageText;
    [SerializeField] private TextMeshProUGUI m_ScoreText;
    [SerializeField] private TextMeshProUGUI m_HighScoreText;

    public void Awake()
    {
        Instance = this;
    }
    public void AssignText(string text)
    {
        m_MessageText.text = text;
    }

    public void UpdateHighScoreText(string value)
    {
        m_HighScoreText.text = "High Score: " + value;
    }

    public void UpdateScoreText(string value)
    {
        m_ScoreText.text = "Score: " + value;
        
    }
}
