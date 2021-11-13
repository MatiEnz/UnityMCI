using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshPro TextMeshProObject;
    void Update()
    {
        TextMeshProObject.text = Global.count.ToString();
    }
}
