using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour

{

   public Text levelNumber;
   public static int current_level = 1;
   public void StartGame()
   {
       SceneManager.LoadScene(1);
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
