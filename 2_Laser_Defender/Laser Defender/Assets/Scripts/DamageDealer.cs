﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] int damage = 100;
    
    public int Damage
    {
        get { return damage; }
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
