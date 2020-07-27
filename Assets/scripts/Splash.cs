using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
        //void OnMouseDown()
        //{
        //    Destroy(gameObject);
        //}

    void Update()
    {
        ReadInput();
    }
    
    void ReadInput()
    {
        if (Input.touchCount > 0)
        {
            Destroy(gameObject);
        }
    }
}
