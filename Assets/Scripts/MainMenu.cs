using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void OpenQuestion(string type){
       DataManager.Instance.questionType = type;
       SceneManager.LoadScene(sceneName:"Question");
   }
}
