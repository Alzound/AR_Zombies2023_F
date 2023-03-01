using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ButtonPlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ButtonCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ButtonBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
