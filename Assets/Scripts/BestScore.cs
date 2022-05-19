using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BestScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    public float receivedBestScore;

    private void Awake()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void QuitApp()
    {
        SaveHighScore();
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void SaveHighScore()
    {
        Debug.Log("HighScore " + PlayerPrefs.GetFloat("HighScore"));
    }
    public void LoadHighScore()
    {
        receivedBestScore = PlayerPrefs.GetFloat("HighScore");
        bestScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        Debug.Log("HighScore " + PlayerPrefs.GetFloat("HighScore"));
    }
    public void ResetScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0f);
        bestScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        Debug.Log("HighScore " + PlayerPrefs.GetFloat("HighScore"));
    }
}
