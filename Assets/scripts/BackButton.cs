using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    Controller control;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controlObj = GameObject.FindGameObjectWithTag("Controller");
        control = controlObj.GetComponent<Controller>();
    }

    void OnMouseDown()
    {
        control.LevelDown();
        control.updateCard();
    }
}
