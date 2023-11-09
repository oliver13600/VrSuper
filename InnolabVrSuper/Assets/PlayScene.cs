using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]

public class PlayScene : MonoBehaviour
{
    public Button button;
    public string sceneToLoad = "Supermarket";
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button?.onClick.AddListener(() => Click());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
