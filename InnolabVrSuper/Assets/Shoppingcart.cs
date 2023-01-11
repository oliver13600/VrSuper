using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoppingcart : MonoBehaviour
{
    public TMP_Text itemCountText; // Reference to the TMP_Text component to display the item count
    private int itemCount = 0; // Current item count

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
