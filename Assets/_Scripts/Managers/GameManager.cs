using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform startPos;
    [SerializeField] private float speedIncreaseRate = .05f;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private int scoreIncreaseRate = 1;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;

    private float timeElapsed = 0f;
    private int score = 0;

    private void Start()
    {
        // Instantiate the ball in the parent object which is startPos
        Instantiate(ballPrefab, startPos.position, Quaternion.identity);
    }

    private void Update()
    {
        IncreaseSpeedByTime();
    }

    public void WinUI()
    {
        winUI.SetActive(true);
        winUI.GetComponentInChildren<TMP_Text>().text = $"You Win!\nScore: {score}";
        Time.timeScale = 0f;
    }

    public void LoseUI()
    {
        loseUI.SetActive(true);
        loseUI.GetComponentInChildren<TMP_Text>().text = $"You Lose!\nScore: {score}";
        Time.timeScale = 0f;
    }

    private string DisplaySpeed() => $"Speed: {BallMovement.Instance.MoveSpeed.ToString("0.0")}"; // Display the speed

    private string DisplayScore() => $"Score: {score}"; // Display the score

    public void UpdateScore()
    {
        score += scoreIncreaseRate; // Increase the score
        scoreText.text = DisplayScore(); // Display the score
    }

    /// <summary>
    /// Increase the speed of the ball by time
    /// </summary>
    private void IncreaseSpeedByTime()
    {
        timeElapsed += Time.deltaTime; // Increase the time elapsed by the time
        float speed = BallMovement.Instance.MoveSpeed + (speedIncreaseRate * timeElapsed) / 50;
        BallMovement.Instance.MoveSpeed = Mathf.Clamp(speed, 0, maxSpeed); // Clamp the speed
        speedText.text = DisplaySpeed(); // Display the speed
    }
}
