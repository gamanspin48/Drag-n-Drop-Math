using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOperasi : MonoBehaviour
{
    public Vector3 piringOriginalPosition;
    public Vector3 appleOriginalPosition;
    public GameObject piringPrefab;
    public GameObject applePrefab;

    public static MainOperasi Instance { get; private set; } // static singleton
    void Awake() {
         DontDestroyOnLoad(this.gameObject);
         if (Instance == null) { Instance = this;  }
         else { Destroy(gameObject); }
         // Cache references to all desired variables
        //  player= FindObjectOfType<Player>();
    }

    public void SpawnObjectApple(){
        Instantiate(applePrefab, appleOriginalPosition, Quaternion.identity);
    }

    public void SpawnObjectPiring(){
        Instantiate(piringPrefab, piringOriginalPosition, Quaternion.identity);
    }

}
