using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LoadSceneButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
