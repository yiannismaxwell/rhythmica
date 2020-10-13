using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

/// <summary>
/// Controls and initialises app
/// </summary>
public class Controller : MonoBehaviour
{
    #region fields
    const int MAX_LENGTH = 4;
    const int MIN_LEVEL = 3; // 1 is blank
    const int MAX_LEVEL = 6; //27;
    const int OFFSET = 64; // half spritewidth
    static List<Unit> units = new List<Unit>();
    static Card card;
    static GameObject[] cells;
    int level;
    int length;
    [SerializeField]
    GameObject prefabCell;
    float cellWidth;
    float screenCentre;

    // previews
    bool previewOn = true;
    [SerializeField]
    GameObject nextPreviewPrefab;
    [SerializeField]
    GameObject backPreviewPrefab;


    // Rhythm unit sprites
    [SerializeField]
    Sprite blankSprite;
    [SerializeField]
    Sprite taSprite;
    [SerializeField]
    Sprite titiSprite;
    [SerializeField]
    Sprite saSprite;
    [SerializeField]
    Sprite tikatikaSprite;
    [SerializeField]
    Sprite titikaSprite;
    [SerializeField]
    Sprite tikatiSprite;
    [SerializeField]
    Sprite taaSprite;
    [SerializeField]
    Sprite tamtiSprite;

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

        // Determine max length according to screenwidth
        GameObject tempCell = Instantiate<GameObject>(prefabCell);
        BoxCollider2D collider = tempCell.GetComponent<BoxCollider2D>();
        cellWidth = collider.size.x;
        Destroy(tempCell);
        screenCentre = ScreenUtils.ScreenLeft + 
            (ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft)/2;


        // instantiate previews
        nextPreviewPrefab = Instantiate<GameObject>(nextPreviewPrefab);
        SpriteRenderer sr = nextPreviewPrefab.GetComponent<SpriteRenderer>();
        float previewWidth = sr.sprite.bounds.size.x;
        Vector3 previewPos = new Vector3(ScreenUtils.ScreenRight - previewWidth,
            ScreenUtils.ScreenBottom + previewWidth, 0);
        nextPreviewPrefab.transform.position = previewPos;

        backPreviewPrefab = Instantiate<GameObject>(backPreviewPrefab);
        sr = backPreviewPrefab.GetComponent<SpriteRenderer>();
        previewPos = new Vector3(ScreenUtils.ScreenLeft + previewWidth,
            ScreenUtils.ScreenBottom + previewWidth, 0);
        backPreviewPrefab.transform.position = previewPos;




        updateCard();
        UpdatePreview();

        AddListeners();

        
    }

    void UpdatePreview()
    {
        if (previewOn)
        {
            SpriteRenderer sr = nextPreviewPrefab.GetComponent<SpriteRenderer>();
            if (level == units.Count)
            {
                sr.sprite = units[0].Sprite;
            }
            else
            {
                sr.sprite = units[Math.Min(level, units.Count - 1)].Sprite;
            }

            sr = backPreviewPrefab.GetComponent<SpriteRenderer>();
            if (level == MIN_LEVEL)
            {
                sr.sprite = units[0].Sprite;
            }
            else
            {
                sr.sprite = units[level - 1].Sprite;
            }
        }
    }

    void AddListeners()
    {
        EventManager.main.onNewCard += updateCard;
        EventManager.main.onNextRhythm += LevelUp;
        EventManager.main.onPreviousRhythm += LevelDown;
    }

      
    void initialiseUnits()
    {
        units.Add(new Unit("blank", 0, blankSprite));
        units.Add(new Unit("ta", 1, taSprite));
        units.Add(new Unit("titi", 1, titiSprite));
        units.Add(new Unit("sa", 1, saSprite));
        units.Add(new Unit("tikatika", 1, tikatikaSprite));
        units.Add(new Unit("titika", 1, titikaSprite));
        units.Add(new Unit("tikati", 1, tikatiSprite));
        units.Add(new Unit("taa", 2, taaSprite));
        units.Add(new Unit("tamti", 2, tamtiSprite));

    }

    public void updateCard()
    {
        card = new Card(units, length, level);

        Unit[] rhythm = card.getUnits;
        for (int i=0; i<length; i++)
        {
            Destroy(cells[i]);
            cells[i] = Instantiate(prefabCell);
            Vector2 screenPos = new Vector2(Screen.width / (length + 1) * (i + 1), Screen.height / 2);
            //Vector2 screenPos = new Vector2(Screen.width / 2 - 3 * cellWidth + 2 *cellWidth* i, Screen.height / 2);

            // Centre 2-beat units
            if (rhythm[i].Name.Equals("tamti"))
            {
                screenPos.x = Screen.width / (length + 1) * (i + (float) 1.5);
            }

            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

            cells[i].transform.position = worldPos;

            SpriteRenderer sr = cells[i].GetComponent<SpriteRenderer>();
            sr.sprite = rhythm[i].Sprite;
        }
    }

    public void LevelUp()
    {
        level = Math.Min(level + 1, units.Count);
        updateCard();
        UpdatePreview();
    }
    
    public void LevelDown()
    {
        level = Math.Max(level - 1, MIN_LEVEL);
        updateCard();
        UpdatePreview();
    }
    #endregion
}
