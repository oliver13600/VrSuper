using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject shoppingCartCollider;
    public TMP_Text productsDisplay;
    public TMP_Text checkoutScreenText;
    public Button purchaseButton;

    public Animation animation1;
    public Animation animation2;

    public string animationName; // Add this line
    public string animationName2; // Add this line

    public List<string> targetTags; // List of tags to check against

    private List<string> productList = new List<string>();

    private List<ProductInfo> productList2 = new List<ProductInfo>();

    public ProductInfo productInfoPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        if (checkoutScreenText != null)
        {
            checkoutScreenText.text = "Welcome to VR Supermarkt!";
        }
        // Initialize the purchase button to be inactive at start
        if (purchaseButton != null)
        {
            purchaseButton.gameObject.SetActive(false);
            purchaseButton.onClick.AddListener(CompletePurchase);
        }

        ProductInfo productInfo = new ProductInfo();
      
        
        // Ensure the shoppingCartCollider has a Collider and set it as a trigger
        if (shoppingCartCollider != null)
        {
            Collider collider = shoppingCartCollider.GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = true;
                PhysicsTriggerEvent triggerEvent = shoppingCartCollider.AddComponent<PhysicsTriggerEvent>();
                triggerEvent.OnTriggerEnterEvent += HandleCollision;
            }
            else
            {
                Debug.LogError("No Collider found on the ShoppingCartCollider GameObject!");
            }
        }
        else
        {
            Debug.LogError("ShoppingCartCollider GameObject not assigned in inspector!");
        }
    }

    private void HandleCollision(Collider other)
    {
        // Check if the colliding object has any of the tags in the list
        if (targetTags.Contains(other.tag))
        {
            string newItem = other.name;
            productList.Add(newItem);
            productsDisplay.text = updateProductDisplay();
            checkoutScreenText.text = updateProductDisplay();
            Destroy(other.gameObject);
        }
        // Activate the purchase button when an item is added to the cart
        if (productList.Count > 0 && purchaseButton != null)
        {
            purchaseButton.gameObject.SetActive(true);
        }
    }

    private void CompletePurchase()
    {
        // Display thank you message
        checkoutScreenText.text = "Thank you for shopping!";

        // Possibly clear the cart here if needed
        productsDisplay.text = "";
        productList.Clear();
        animation1.Play(animationName); // Modify this line
        animation2.Play(animationName2); // Modify this line
        // Deactivate the purchase button after purchase
        purchaseButton.gameObject.SetActive(false);
    }

    private string updateProductDisplay()
    {
        string result = "";
        foreach(string product in productList)
        {
            result = result + "\n" + product;
        }
        return result;
    }

    // Update is called once per frame
    /*void Update()
    {
        productsDisplay.text = updateProductDisplay();
        checkoutScreenText.text = updateProductDisplay();
    }*/
}

// Helper class to handle physics trigger events
public class PhysicsTriggerEvent : MonoBehaviour
{
    public delegate void TriggerEvent(Collider other);
    public event TriggerEvent OnTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke(other);
    }
}
