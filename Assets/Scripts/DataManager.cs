using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DataManager : MonoBehaviour
{   

     public string questionType;
     public Soal[] multiplyQuestions;
     public Soal[] divideQuestions;
     public Soal[] fracQuestions;
     public Soal[] percentQuestions;  
     public Soal[] soalChoosen;  
     public static DataManager Instance { get; private set; } // static singleton
     void Awake() {
          DontDestroyOnLoad(this.gameObject);
          if (Instance == null) { Instance = this;  }
          else { Destroy(gameObject); }
          // Cache references to all desired variables
          //  player= FindObjectOfType<Player>();
     }

     public Soal[] Randomize(Soal []arr, int n) 
    { 
        // Creating a object 
        // for Random class 
        Soal[] tempSoal = new Soal[n];
        System.Random r = new System.Random(); 
          
        // Start from the last element and 
        // swap one by one. We don't need to 
        // run for the first element  
        // that's why i > 0 
        var numbers = new List<int>();
        for (int i = n - 1; i >= 0; i--)  
        { 
              
            // Pick a random index 
            // from 0 to i 
             int j;
            do
            {
                 j = r.Next(0, arr.Length); 
            } while (numbers.Contains(j) );
           numbers.Add(j);
     //    Console.Write(arr[i] + " "); 
              
            // Swap arr[i] with the 
            // element at random index 
          //   int temp = arr[i]; 
            tempSoal[i] = arr[j]; 
          //   Debug.Log(tempSoal[i].textSoal);
          //   arr[j] = temp; 
        } 
        // Prints the random array 
     //    for (int i = 0; i < n; i++) 
     //    Console.Write(arr[i] + " "); 
          return tempSoal;
    } 
}
