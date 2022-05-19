using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    AudioSource clip;
    private void Start()
    {
        clip = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        Circle.destroyedCircles = 0;
        SceneManager.LoadScene("MainGame");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ResetScoreButtonSFX()
    {
        clip.Play();
    }
}
