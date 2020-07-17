using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Rhythmic unit
/// </summary>
public class Unit : MonoBehaviour
{
    private string name;
    private int val;
    private Sprite sprite;


    public Unit(string name, int val, Sprite sprite)
    {
        this.name = name;
        this.val = val;
        this.sprite = sprite;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Val
    {
        get => val;
        set => val = value;
    }

    public Sprite Sprite
    {
        get => sprite;
    }

    public void printUnit()
    {
        print("Unit: " + name);
        print("Value: " + val);
    }
}
