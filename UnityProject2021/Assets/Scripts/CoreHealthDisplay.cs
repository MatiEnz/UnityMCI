using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHealthDisplay : MonoBehaviour
{

    public Image img;
    public Text core_health;

    private void Update()
    {
        int percentage = 100 - (Global.count*5);
        string fulltext = percentage.ToString() + "%";
        core_health.text = fulltext;
        img.transform.position = Camera.main.WorldToScreenPoint(Placer.newOrigin.position + (Placer.newOrigin.up * 0.15f));
    }
}