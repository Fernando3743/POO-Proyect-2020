using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;

    public GameObject optionsPanel;

    public GameObject panelOrdenes;

    private void Start()
    {
        Time.timeScale = 1;
        panelOrdenes.SetActive(true);
    }
    public void OptionsPanel()
    {
        Time.timeScale = 0;
        panelOrdenes.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void Return()
    {
        Time.timeScale = 1;
        panelOrdenes.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void PlaySoundButton()
    {
        clip.Play();
    }
}
