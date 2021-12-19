using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
     public static int count = 0;
     public static int points = 0;

     public Text pointText;

         private void Update()
    {
        
        pointText.text = points.ToString();
    }
}
