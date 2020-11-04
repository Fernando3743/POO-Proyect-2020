using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource clip;
    public void startGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void PlaySoundButton()
    {
        clip.Play();
    }
}
