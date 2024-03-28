using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArmy 
{
    private string armyName;
    private float price;    

    public GameArmy(string armyName, float price){
        this.armyName = armyName;
        this.price = price;
       
    }
    
    public string Name
    {
        get { return armyName; }
        set { armyName = value; }
    }
    public float Price
    {
        get { return price; }
        set { price = value; }
    }
 
   
}


