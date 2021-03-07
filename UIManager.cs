using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel;

    public AudioSource clip;

    public void OptionPanel()
    {
        Debug.Log("누름");
        Time.timeScale = 0;
        optionPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionPanel.SetActive(false);
    }

    public void AnotherOption()
    { 
      //Sound
      //Graphics
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
        
    }
}
