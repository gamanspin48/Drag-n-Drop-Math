using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainOperasi : MonoBehaviour
{
    public Vector3 piringOriginalPosition;
    public Vector3 appleOriginalPosition;
    public GameObject piringPrefab;
    public GameObject applePrefab;

    public GameObject mainBoard;
    public Soal soal;
    public int currentJmlPiring;
    public int currentJmlApple;
    public int index;

    public Text answerText;
    public Text descText;
    public Text soalText;
    public Button btnNext;

    public static MainOperasi Instance { get; private set; } // static singleton
    void Awake() {
         DontDestroyOnLoad(this.gameObject);
         if (Instance == null) { Instance = this;  }
         else { Destroy(gameObject); }
         // Cache references to all desired variables
        //  player= FindObjectOfType<Player>();
        index = 0;
    }

    void Start(){
        InitSoal();
    }

    public void InitSoal(){
        soal = DataManager.Instance.soalChoosen[index];
        currentJmlApple = 0;
        currentJmlPiring = 0;
        RemoveAllChildren();
        soalText.text = soal.textSoal;
        answerText.text = "";
        descText.text = "";
        btnNext.gameObject.SetActive(false);
    }

    public void NextSoal(){
        if (index < DataManager.Instance.soalChoosen.Length){
            InitSoal();
        }else{
            SceneManager.LoadScene(sceneName:"MainMenu");
        }
    }

    public void SpawnObjectApple(){
        Instantiate(applePrefab, appleOriginalPosition, Quaternion.identity);
    }

    public void SpawnObjectPiring(){
        Instantiate(piringPrefab, piringOriginalPosition, Quaternion.identity);
    }

    public void RemoveAllChildren(){
        foreach (Transform child in mainBoard.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
    public ArrayList IsJumlahChildSama(){
        Transform [] t = mainBoard.GetComponentsInChildren<Transform>();
        bool result = false;
        int jmlPiring, jmlApple;
        jmlPiring = 0;
        jmlApple = 0;
        if (t.Length > 1){
            int jml = mainBoard.transform.GetChild(0).childCount;
            int len = mainBoard.transform.childCount;
            result = true;
            jmlPiring = len;
            jmlApple = jml;
            for (int i = 1; i < len; i++)
            {   
                // Debug.Log(mainBoard.transform.GetChild(i).gameObject.name +' '+mainBoard.transform.GetChild(i).childCount);
                 if (jml != mainBoard.transform.GetChild(i).childCount){
                    result = false;
                    break;
                }
            }
        }
       
        var results = new ArrayList() { result, jmlPiring, jmlApple };
        return results;
    }

    public void Validate(){
        bool result = false;
        ArrayList data = IsJumlahChildSama();
        if ((bool)data[0]){
            int jmlPiring = (int)data[1];
            int jmlApple = (int)data[2];
            int indexSoal = soal.IsCorrect(jmlPiring,jmlApple);
            if ( indexSoal != -1){
                answerText.text = soal.textJawaban;
                descText.text = soal.validasi[indexSoal].textDescription;
                btnNext.gameObject.SetActive(true);
                index++;
            }else{
                RemoveAllChildren();
                
            }
        }
    }

}
