using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
     public static int count = 0;
     public static int points = 0;
     public static int neededPoints = 10;
     public Text pointText;
     public Text neededPointText;


    void Start() {

        if(StartMenu.current_level == 1)
        {
            neededPoints = 10;
        }
        if(StartMenu.current_level == 2)
        {
            neededPoints = 20;
        } 
        if(StartMenu.current_level == 3)
        {
            neededPoints = 30;
        }
    }
    void Update()
    {
        
        pointText.text = points.ToString();
        neededPointText.text = neededPoints.ToString();


        if(points >= neededPoints)
        {
            SceneManager.LoadScene(2);
        }   

        if(count >= 20)
        {
            SceneManager.LoadScene(3);
        }    
    }
}
