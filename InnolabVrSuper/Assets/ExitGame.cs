using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitGame : MonoBehaviour
{
    public Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button?.onClick.AddListener(() => Click());

    }

    public void Click()
    {
        // This will close the application
        Application.Quit();

        // If running in the Unity editor, then also stop playing
        //#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
        //#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
