using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]


public class diary_and_cheese_trigger : MonoBehaviour
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
        obj = GameObject.FindGameObjectWithTag("diary_and_cheese");
        obj.AddComponent<outline_diary_and_cheese>();
        Debug.Log("cheese");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
