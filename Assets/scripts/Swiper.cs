using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Swiper : MonoBehaviour
{
    #region fields
    // swipe handlers
    Vector3 firstPos;
    Vector3 lastPos;
    float dragDistance;
    // level controller object
    Controller control;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        dragDistance = (float) 0.2 * Screen.height;

        GameObject controlObj = GameObject.FindGameObjectWithTag("Controller");
        control = controlObj.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadSwipe();
    }

    void ReadSwipe()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstPos = touch.position;
                lastPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lastPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lastPos = touch.position;

                // check drag distance
                if (Math.Abs(lastPos.x - firstPos.x) > dragDistance)
                {
                    // check drag direction
                    if (lastPos.x > firstPos.x)
                    {
                        control.LevelUp();
                        control.updateCard();
                        print("Swipe right");
                    }
                    else
                    {
                        control.LevelDown();
                        control.updateCard();
                        print("Swipe left");
                    }
                }
                else
                {
                    control.updateCard();
                    print("press");
                }
            }
        }
    }

}
