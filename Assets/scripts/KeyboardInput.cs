using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey("left"))
            {
                EventManager.main.TriggerPreviousRhythm();
            }
            if (Input.GetKey("right"))
            {
                EventManager.main.TriggerNextRhythm();
            }
            if (Input.GetKey("space") || Input.GetKey("return"))
            {
                EventManager.main.TriggerNewCard();
            }
        }
    }
}
