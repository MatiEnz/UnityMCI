using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public TextMeshPro TextMeshProObject;
    void Update()
    {
        if(Global.count >= 20)
        {
         SceneManager.LoadScene(3);
        }
        else
        {
        TextMeshProObject.text = Global.count.ToString();    
        }
    }
}
