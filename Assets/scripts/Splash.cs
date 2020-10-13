using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Splash screen for touch inputs
/// </summary>
public class Splash : MonoBehaviour
{
    public string sceneToLoad;

    void Update()
    {
        ReadInput();
    }
    
    void ReadInput()
    {
        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
