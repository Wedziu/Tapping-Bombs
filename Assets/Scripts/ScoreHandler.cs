using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreHandler : MonoBehaviour
{
    [SerializeField] int pointsStart = 0;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI currentTimeText;
    [SerializeField] TextMeshProUGUI tappedCandiesText;
    [SerializeField] float currentTime;
    [SerializeField] public static int currentScore;
    [SerializeField] public static float bestScore;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameObject personalBestInfo;
    AudioSource clip;
    // Start is called before the first frame update
    private void Awake()
    {
        endGamePanel.SetActive(false);
        personalBestInfo.SetActive(false);
        
    }
    void Start()
    {
        clip = GetComponent<AudioSource>();
        currentTime = 0f;
        currentScore = 0;
        currentScoreText.text = "Score: " + pointsStart;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTimeText.text = currentTime.ToString("F2");
        currentScoreText.text = "Score: " + currentScore;
        
    }

    public void EndGame()
    {
        GameObject[] circles;
        circles = GameObject.FindGameObjectsWithTag("Circle");
        foreach(GameObject circle in circles)
        {
            Destroy(circle);
        }
        GameObject[] bombs;
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach(GameObject bomb in bombs)
        {
            Destroy(bomb);
        }
        Time.timeScale = 0;
        endGamePanel.SetActive(true);
        clip.Play();
        tappedCandiesText.text = Circle.destroyedCircles.ToString() ;
        NewPersonalBest();
    }
    private void NewPersonalBest()
    {
        if (PlayerPrefs.GetFloat("HighScore") < currentScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            personalBestInfo.SetActive(true);
        }
    }
}
