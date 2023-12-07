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

    public List<GameObject> productList;
    public TMP_Text productNamesText; // Reference to the TMP_Text component to display the product names

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
        UpdateProductNamesText();
    }

    private void OnSelectExited(XRBaseInteractor interactor)
    {
        
    }

    public void AddItemToCart()
    {
        
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
        itemCountText.text = "Items: " + itemCount.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("liquors_and_softdrinks") || collision.gameObject.CompareTag("housekeeping") || collision.gameObject.CompareTag("pastas_and_condiments"))
        {
            productList.Add(collision.gameObject);
            Destroy(collision.gameObject);
            UpdateProductNamesText();
        }
    }

    private void UpdateProductNamesText()
    {
        string productNames = "Products: ";

        foreach (GameObject product in productList)
        {
            string productName = product.name;
            productNames += productName + ", ";
        }

        productNamesText.text = productNames.TrimEnd(',', ' '); // Trim the trailing comma and space
    }
}