using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;
    // Start is called before the first frame update
    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Fruits"){
            score.text = (int.Parse(score.text) + 1).ToString();
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Bomb"){
            transform.position = new Vector2 (0,100);
            other.gameObject.SetActive(false);
            StartCoroutine(Restart());
        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime (2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
