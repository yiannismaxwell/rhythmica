using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// New card on click for Windows mode
/// </summary>

public class Clicker : MonoBehaviour
{
    void OnMouseDown()
    {
        EventManager.main.TriggerNewCard();
    }
}
