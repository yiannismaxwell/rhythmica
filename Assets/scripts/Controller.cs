using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls and initialises app
/// </summary>
public class Controller : MonoBehaviour
{
    #region fields
    const int MAX_LENGTH = 5;
    const int MIN_LEVEL = 2; // 1 is blank
    const int MAX_LEVEL = 6; //27;
    static List<Unit> units = new List<Unit>();
    static Card card;
    static GameObject[] cells;
    int level;
    int length;
    [SerializeField]
    GameObject prefabCell;

    // Rhythm unit sprites
    [SerializeField]
    Sprite blankSprite;
    [SerializeField]
    Sprite blueSprite;
    [SerializeField]
    Sprite jelloSprite;
    [SerializeField]
    Sprite restSprite;
    [SerializeField]
    Sprite jellojelloSprite;
    [SerializeField]
    Sprite twoSprite;
    [SerializeField]
    Sprite pineappleSprite;
    [SerializeField]
    Sprite restrestSprite;
    [SerializeField]
    Sprite huckleberrySprite;
    [SerializeField]
    Sprite fourSprite;
    [SerializeField]
    Sprite restrestrestrestSprite;
    [SerializeField]
    Sprite purpleSprite;
    [SerializeField]
    Sprite gooseberrySprite;
    [SerializeField]
    Sprite berrygooseSprite;
    [SerializeField]
    Sprite cookieSprite;
    [SerializeField]
    Sprite cucumberSprite;
    #endregion

    #region methods

    // Start is called before the first frame update
    void Start()
    {
        initialiseUnits();
        cells = new GameObject[MAX_LENGTH];

        length = MAX_LENGTH;
        level = MIN_LEVEL;

        Card card = new Card(units, MAX_LENGTH, level);
        //card.printCard();
        updateCard();
        
    }

      
    void initialiseUnits()
    {
        units.Add(new Unit("blank", 0, blankSprite));
        units.Add(new Unit("blue", 1, blueSprite));
        units.Add(new Unit("jello", 1, jelloSprite));
        units.Add(new Unit("rest", 1, restSprite));
        units.Add(new Unit("jellojello", 2, jellojelloSprite));
        units.Add(new Unit("two", 2, twoSprite));
        units.Add(new Unit("pineapple", 1, pineappleSprite));
        units.Add(new Unit("restrest", 2, restrestSprite));
        units.Add(new Unit("huckleberry", 1, huckleberrySprite));
        units.Add(new Unit("four", 4, fourSprite));
        units.Add(new Unit("restrestrestrest", 4, fourSprite));
        units.Add(new Unit("purple", 1, purpleSprite));
        units.Add(new Unit("gooseberry", 1, gooseberrySprite));
        units.Add(new Unit("berrygoose", 1, berrygooseSprite));
        units.Add(new Unit("cookie", 1, cookieSprite));
        units.Add(new Unit("cucumber", 1, cucumberSprite));

    }

    public void updateCard()
    {
        card = new Card(units, length, level);
        //card.printCard();

        Unit[] rhythm = card.getUnits;
        for (int i=0; i<length; i++)
        {
            Destroy(cells[i]);
            cells[i] = Instantiate(prefabCell);
            Vector2 screenPos = new Vector2(Screen.width / (length + 1) * (i + 1), Screen.height / 2);
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            cells[i].transform.position = worldPos;

            SpriteRenderer sr = cells[i].GetComponent<SpriteRenderer>();
            sr.sprite = rhythm[i].Sprite;
        }


    }

    public void LevelUp()
    {
        level = Math.Min(level + 1, units.Count);
        print(level);
    }
    
    public void LevelDown()
    {
        level = Math.Max(level - 1, MIN_LEVEL);
        print(level);
    }
    #endregion
}
