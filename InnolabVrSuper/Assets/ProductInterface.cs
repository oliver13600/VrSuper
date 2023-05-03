using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ProductInterface : MonoBehaviour
{
    private XRGrabInteractable interactable;

    public GameObject ui;
    

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        interactable.onSelectEnter.AddListener(OnSelectEntered);
        interactable.onSelectExited.RemoveListener(OnSelectExited);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // Activate the objectToActivate when the parent object is grabbed
        Debug.Log("TestSetActive");
        ui.SetActive(true);
    }

    private void OnSelectExited(XRBaseInteractor interactor)
    {
        // Deactivate the game object when the parent object is released
        Debug.Log("TestSetActiveFalse");
        ui.SetActive(false);
    }
}
