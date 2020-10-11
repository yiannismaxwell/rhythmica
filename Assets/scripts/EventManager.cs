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
    

}
