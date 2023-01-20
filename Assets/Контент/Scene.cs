using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void PauseOff()
    {
        Time.timeScale = 1.0f;
    }
}
