using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToSceneGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoToSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
