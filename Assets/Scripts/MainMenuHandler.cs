using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("gameScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("main-menu");
    }
    public void WinScreen()
    {
        SceneManager.LoadScene("win-scene");
    }
    public void LoseScreen()
    {
        SceneManager.LoadScene("lose-scene");
    }
}
