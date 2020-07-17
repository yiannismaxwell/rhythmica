using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Unit[] card;
    private int length;
    private System.Random rand = new System.Random();

    
    
    // constructor
    public Card(List<Unit> units, int length, int level)
    {
        this.length = length;
        card = new Unit[length];
        // initialise units (construct card array)
        for (int i=0; i<length; i++)
        {
            card[i] = units[0];
        }
        int cell = 0;
        while (cell < length)
        {
            Unit newUnit = units[rand.Next(level)]; // TODO: exception handle level > number of units
            while (TotalVal() + newUnit.Val > length)
            {
                newUnit = units[rand.Next(level)];
            }
            card[cell] = newUnit;
            cell += newUnit.Val;
        }
    }
    
    // Total rhythmic value of card
    private int TotalVal()
    {
        int sum = 0;
        foreach (Unit unit in card)
        {
            sum += unit.Val;
        }
        return sum;
    }

    // print units' names and values to console
    public void printCard()
    {
        foreach (Unit unit in card)
        {
            unit.printUnit();
        }
    }

    public Unit[] getUnits
    {
        get => card;
    }

}
