using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outline_non_alcohilic_drinks : MonoBehaviour
{
    public GameObject obj;
    //public static bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        //var products = transform.Find("Pasta_g87jtq");
        //obj.GetComponent;
        //var outline = gameObject.AddComponent<Outline>();


        //outline.OutlineColor = Color.yellow;
        //outline.OutlineWidth = 7f;
        //Debug.Log(gameObject.name); 
        //var prout = products.GetComponent<Outline>();
        //prout.OutlineColor = Color.green;
        //prout.OutlineWidth = 7f;

        //outline.enabled = !outline.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "non_alcoholic_drinks")
        {
            //if (gameObject.GetComponent<Outline>())
            //{
            var outline = gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.gray;
            outline.OutlineWidth = 9f;
            outline.OutlineMode = Outline.Mode.OutlineVisible;
            //}
        }
        Debug.Log(gameObject.tag);
    }
}
