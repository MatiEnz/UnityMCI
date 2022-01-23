using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
   public Text finalPoints;
   public Text HSText;
void Update()
{
    finalPoints.text = Global.points.ToString();
    if(Global.points>PlayerPrefs.GetInt("HighScore", 0))
    {
    PlayerPrefs.SetInt("HighScore", Global.points);
    HSText.text= Global.points.ToString();
    }
}
   public void BackToMenu()
   {
       SceneManager.LoadScene(0);
   }

}
