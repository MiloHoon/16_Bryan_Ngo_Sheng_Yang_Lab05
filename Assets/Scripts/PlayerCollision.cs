using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private int score;
    private int coins;

    public int timeRemaining;
    public float timeLeft;

    public Text ScoreText;
    public Text TimerText;

    public GameObject particles;

    // Update is called once per frame
    void Update()
    {
        TimerScript();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            score += 10;
            ScoreText.text = "Score: " + score;
            var clone = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(clone, 5.0f);
            Destroy(other.gameObject);

            if (coins == 6)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (other.gameObject.tag == "Fire")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    public void TimerScript()
    {
        timeLeft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeLeft % 60);
        TimerText.text = "Timer: " + timeRemaining.ToString();

        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
