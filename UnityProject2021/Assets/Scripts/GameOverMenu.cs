using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
   public Text finalPoints;
void Update()
{
    finalPoints.text = Global.points.ToString();
}
   public void BackToMenu()
   {
       SceneManager.LoadScene(0);
   }

}
