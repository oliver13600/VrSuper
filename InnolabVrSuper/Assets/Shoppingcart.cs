using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
public class Shoppingcart : MonoBehaviour
{
    public TMP_Text itemCountText; // Reference to the TMP_Text component to display the item count
    private int itemCount = 0; // Current item count
    public GameObject ui;
    private XRGrabInteractable interactable;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        interactable.onSelectEnter.AddListener(OnSelectEntered);
        interactable.onSelectExited.AddListener(OnSelectExited);
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

    public void AddItemToCart()
    {
        itemCount++;
        UpdateItemCountText();
    }

    public void RemoveItemFromCart()
    {
        if (itemCount > 0)
        {
            itemCount--;
            UpdateItemCountText();
        }
    }

    private void UpdateItemCountText()
    {
        itemCountText.text = "Item count: " + itemCount;
    }
}
