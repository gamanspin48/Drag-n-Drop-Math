using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void OpenQuestion(string type){
       DataManager.Instance.questionType = type;
       int jmlSoal = 10;
       Soal[] soalChoosen = new Soal[jmlSoal];
       if (type == "multiply"){
           soalChoosen = DataManager.Instance.multiplyQuestions;
       }else if (type == "divide"){
           soalChoosen = DataManager.Instance.divideQuestions;
       }else if (type == "frac"){
           soalChoosen = DataManager.Instance.fracQuestions;
       }
       Soal[] tempSoal = DataManager.Instance.Randomize(soalChoosen,jmlSoal);
       for (int i = 0; i < tempSoal.Length; i++){
           Debug.Log(tempSoal[i].textSoal);
       }
       DataManager.Instance.soalChoosen = tempSoal;
       SceneManager.LoadScene(sceneName:"Question");
   }
}
