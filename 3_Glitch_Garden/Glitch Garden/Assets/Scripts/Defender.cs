using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    [SerializeField] int starCost = 100;

    

    private void Start()
    {
        if (PlayerSettings.GetDifficulty() == 0)
        {
            Debug.Log("A" + starCost);
            // Easy - half the price of all things
            starCost /= 2;
            Debug.Log("B" + starCost);
        }
        else if (PlayerSettings.GetDifficulty() == 1)
        {
            // Medium - Do nothing with cost
        }
        else
        {
            // Hard - double the price
            Debug.Log("C" + starCost);
            starCost *= 2;
            Debug.Log("D" + starCost);
        }

        Debug.Log("D" + starCost);
    }


    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }


    public int StarCost
    {
        get { return starCost; }
    }
       
}
