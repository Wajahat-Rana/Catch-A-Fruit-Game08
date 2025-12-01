using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int currentScore = 0;

    private int highScore = 0;

    void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        // Load saved high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        scoreText.text = "0";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fruits")
        {
            currentScore++;
            scoreText.text = currentScore.ToString();
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Bomb")
        {
            transform.position = new Vector2(0, 100);
            other.gameObject.SetActive(false);

            SaveHighScore();   // Save high score before restarting

            StartCoroutine(Restart());
        }
    }

    void SaveHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Gameplay");
    }
}
