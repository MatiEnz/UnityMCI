using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshPro TextMeshProObject;
    void Update()
    {
        if(Global.count >= 20)
        {
        TextMeshProObject.text = ":(";
        }
        else
        {
        TextMeshProObject.text = Global.count.ToString();    
        }
    }
}
