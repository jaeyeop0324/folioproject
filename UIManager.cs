using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel;

    public AudioSource clip;

    public void OptionPanel()   //일시정지
    {
        Time.timeScale = 0;
        optionPanel.SetActive(true);
    }

    public void Return()        //돌아가기
    {
        Time.timeScale = 1;
        optionPanel.SetActive(false);
    }

    public void AnotherOption()
    { 
      //Sound
      //Graphics
    }

    public void GoMainMenu()     //메인메뉴로 이동
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()      //게임종료
    {
        Application.Quit();
    }

    public void PlaySoundButton()       //사운드 조절 예정중
    {
        clip.Play();
    }
}
