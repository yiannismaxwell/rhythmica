using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Splash screen for touch inputs
/// </summary>
public class MouseSplash : MonoBehaviour
{
    public string sceneToLoad;
    
    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
