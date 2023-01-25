using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]


public class pastas_and_condinments_trigger : MonoBehaviour
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
        obj = GameObject.FindGameObjectWithTag("pastas_and_condinments");
        obj.AddComponent<outline_pastas_and_condinments>();
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
