using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Oculus.Platform.Models;

public class EndScreenDisplay : MonoBehaviour
{
    List<string> finalProductList = new List<string>();

    public TMP_Text productsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        finalProductList = GlobalData.GlobalProductList;

        

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        productsDisplay.text = updateProductDisplay();
    }

    private string updateProductDisplay()
    {
        string result = "";
        foreach (string product in finalProductList)
        {
            result = result + "\n" + product;
        }
        return result;
    }
}
