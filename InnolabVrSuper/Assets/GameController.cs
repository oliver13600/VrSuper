using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject shoppingCartCollider;
    public TMP_Text productsDisplay;
    public List<string> targetTags; // List of tags to check against

    private List<string> productList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(other.gameObject);
        }
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
    void Update()
    {
        productsDisplay.text = updateProductDisplay();
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
