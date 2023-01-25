using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]


public class liquors_and_softdrinks_trigger : MonoBehaviour
{

    public Button button;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button?.onClick.AddListener(() => Click());

    }


    public void Click()
    {
        obj = GameObject.FindGameObjectWithTag("liquors_and_softdrinks");
        obj.AddComponent<outline_liquors_and_softdrinks>();
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
