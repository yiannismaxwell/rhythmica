using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPreview : MonoBehaviour
{

    void OnMouseDown()
    {
        EventManager.main.TriggerNextRhythm();
    }

}
