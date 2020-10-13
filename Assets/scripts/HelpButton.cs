using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // place help icon on top right of screen
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float width = sr.sprite.bounds.size.x;
        Vector3 pos = new Vector3(ScreenUtils.ScreenRight - width,
            ScreenUtils.ScreenTop - width, -1f);
        transform.position = pos;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("newcard");
    }
}
