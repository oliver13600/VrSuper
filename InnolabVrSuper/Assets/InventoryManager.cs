/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InventoryManager : MonoBehaviour
{
    // A list to store the items in the inventory
    public List<GameObject> inventory = new List<GameObject>();

    // A UI element to display the inventory
    public GameObject inventoryUI;

    // A prefab for the inventory UI item
    public GameObject inventoryItemPrefab;

    // The XR Interaction Manager
    public XRInteractionManager interactionManager;

    private void Awake()
    {
        // Subscribe to the interaction manager's interaction events
        interactionManager.onPickUp.AddListener(OnPickUp);
        interactionManager.onDrop.AddListener(OnDrop);
    }

    // A method to handle pick-up events
    private void OnPickUp(XRBaseInteractable interactable)
    {
        // Check if the interactable is an item
        Item item = interactable.GetComponent<Item>();
        if (item != null)
        {
            // Add the item to the inventory
            AddItem(interactable.gameObject);
        }
    }

    // A method to handle drop events
    private void OnDrop(XRBaseInteractable interactable)
    {
        // Check if the interactable is an item
        Item item = interactable.GetComponent<Item>();
        if (item != null)
        {
            // Remove the item from the inventory
            RemoveItem(interactable.gameObject);
        }
    }

    // A method to add an item to the inventory
    public void AddItem(GameObject item)
    {
        // Add the item to the inventory list
        inventory.Add(item);

        // Update the inventory UI
        UpdateInventoryUI();
    }
// A method to remove an item from the inventory
    public void RemoveItem(GameObject item)
    {
        // Remove the item from the inventory list
        inventory.Remove(item);

        // Update the inventory UI
        UpdateInventoryUI();
    }

    // A method to update the inventory UI
    public void UpdateInventoryUI()
    {
        // Clear the existing inventory UI items
        foreach (Transform child in inventoryUI.transform)
        {
            Destroy(child.gameObject);
        }

        // Add an inventory UI item for each item in the inventory
        foreach (GameObject item in inventory)
        {
            // Create a new inventory UI item
            GameObject inventoryItem = Instantiate(inventoryItemPrefab, inventoryUI.transform);

            // Set the name and description of the inventory UI item
            inventoryItem.GetComponent<InventoryItemUI>().nameText.text = item.name;
            inventoryItem.GetComponent<InventoryItemUI>().descriptionText.text = item.GetComponent<Item>().description;

            // Add a button to use the item
            inventoryItem.GetComponent<InventoryItemUI>().useButton.onClick.AddListener(() => UseItem(item));
        }
    }

    // A method to use an item from the inventory
public void UseItem(GameObject item)
{
    // Do something with the item (e.g. apply a power-up, solve a puzzle, etc.)
    item.GetComponent<Item>().Use();

    // Remove the item from the inventory
    RemoveItem(item);
}
}*/