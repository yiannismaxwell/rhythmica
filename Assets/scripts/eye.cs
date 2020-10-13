using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{
    void OnMouseDown()
    {
        EventManager.main.TriggerHide();
    }
}
