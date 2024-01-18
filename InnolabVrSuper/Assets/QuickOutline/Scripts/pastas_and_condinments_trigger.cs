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
        GameObject[] diaryObjects = GameObject.FindGameObjectsWithTag("vegan");



        foreach (GameObject diaryObject in diaryObjects)
        {
            // Check if the object already has an "Outline" component
            if (diaryObject.GetComponent<Outline>() == null)
            {
                var outline = diaryObject.AddComponent<Outline>();
                outline.OutlineColor = Color.red;
                outline.OutlineWidth = 7f;
                outline.OutlineMode = Outline.Mode.OutlineVisible;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
