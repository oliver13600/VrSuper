using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ProductInterface : MonoBehaviour
{
    private XRGrabInteractable interactable;

    

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        interactable = GetComponentInParent<XRGrabInteractable>();

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
        gameObject.SetActive(true);
    }

    private void OnSelectExited(XRBaseInteractor interactor)
    {
        // Deactivate the game object when the parent object is released
        gameObject.SetActive(false);
    }
}
