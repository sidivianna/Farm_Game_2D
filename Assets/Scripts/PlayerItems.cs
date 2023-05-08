using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public int totalWood;
    public int carrots;

    public float currentWater;
    private float waterLimit = 50;
    
    public void WaterLimit(float water) 
    {
        if (currentWater <= waterLimit) 
        {
            currentWater += water;
        }
        
    }
}
