using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager main;

    public event Action onNewCard;
    public event Action onNextRhythm;
    public event Action onPreviousRhythm;
    public event Action onHide;

    void Awake()
    {
        main = this;
    }

    public void TriggerNewCard()
    {
        onNewCard?.Invoke();
    }

    public void TriggerNextRhythm()
    {
        onNextRhythm?.Invoke();
    }

    public void TriggerPreviousRhythm()
    {
        onPreviousRhythm?.Invoke();
    }

    /// <summary>
    /// Event for hiding previews
    /// </summary>
    public void TriggerHide()
    {
        onHide?.Invoke();
    }
    

}
