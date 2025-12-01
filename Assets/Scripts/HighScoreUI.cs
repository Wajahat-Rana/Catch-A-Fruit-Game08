using UnityEngine;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int high = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + high.ToString();
    }
}
