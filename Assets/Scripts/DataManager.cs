﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{   
    [HideInInspector]
    public string questionType;
    public static DataManager Instance { get; private set; } // static singleton
    void Awake() {
         DontDestroyOnLoad(this.gameObject);
         if (Instance == null) { Instance = this;  }
         else { Destroy(gameObject); }
         // Cache references to all desired variables
        //  player= FindObjectOfType<Player>();
     }
}
