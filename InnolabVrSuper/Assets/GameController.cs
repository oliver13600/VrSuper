using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject shoppingCartCollider;
    public TMP_Text productsDisplay;
    public TMP_Text checkoutScreenText;
    public Button purchaseButton;
    public AudioSource audioSource;
    public GameObject door1;
    public GameObject door2;
    public GameObject door1_2;
    public GameObject door2_2;

    public List<string> targetTags; // List of tags to check against

    private List<string> productList = new List<string>();

    private List<ProductInfo> productList2 = new List<ProductInfo>();

    public ProductInfo productInfoPrefab;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the purchase button to be inactive at start
        if (purchaseButton != null)
        {
            purchaseButton.gameObject.SetActive(false);
            purchaseButton?.onClick.AddListener(() => CompletePurchase());
        }
        door1_2.SetActive(false);
        door2_2.SetActive(false);

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
        audioSource.Play();
        door1.SetActive(false);
        door2.SetActive(false);
        door1_2.SetActive(true);
        door2_2.SetActive(true);

        // Possibly clear the cart here if needed
        productsDisplay.text = "";
        GlobalData.GlobalProductList = new List<string>(productList);
        productList.Clear();

        // Deactivate the purchase button after purchase
        purchaseButton.gameObject.SetActive(false);
        StartCoroutine(LoadEndScreenAfterDelay(5));
    }

    private string updateProductDisplay()
    {
        string result = "";
        foreach (string product in productList)
        {
            result = result + "\n" + product;
        }
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        if (productList.Count > 0)
        {
            productsDisplay.text = updateProductDisplay();
            checkoutScreenText.text = updateProductDisplay();
        }
    }

    IEnumerator LoadEndScreenAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene("EndScreen"); // Load the EndScreen scene
    }
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

public static class GlobalData
{
    public static List<string> GlobalProductList { get; set; } = new List<string>();
}

