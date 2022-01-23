using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour

{


   public Text levelNumber;
   public static int current_level = 1;
   public Text HSText;
  

   public void StartGame()
   {
       SceneManager.LoadScene(0);
      HSText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
   }
 public void levelSelect()
  {
    current_level = current_level + 1;
    if(current_level > 3)
    {
      current_level = 1;
    }

    levelNumber.text = current_level.ToString();


  }
}
