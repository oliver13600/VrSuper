using UnityEngine;
using TMPro;
using UnityEngine.UI; // Required for UI elements like Button

public class ItemScanner : MonoBehaviour
{
    public AudioSource beepSound;
    public TextMeshPro itemCountText;
    public TextMeshPro[] otherTextsToDeactivate; // Array of other TextMeshPro objects to deactivate
    public Button checkoutButton; // Reference to the checkout button

    private int itemCount = 0;
    private bool firstScanHappened = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the tag "product"
        if (other.gameObject.tag == "product")
        {
            itemCount++;
            UpdateItemCountDisplay();

            // Play the beep sound
            if (beepSound != null)
            {
                beepSound.Play();
            }

            // Handle first scan
            if (!firstScanHappened)
            {
                firstScanHappened = true;
                HandleFirstScan();
            }
        }
    }

    private void UpdateItemCountDisplay()
    {
        // Update the TextMeshPro text to show the current item count
        if (itemCountText != null)
        {
            itemCountText.text = "Items Scanned: " + itemCount;
        }
    }

    private void HandleFirstScan()
    {
        // Deactivate other texts
        foreach (var text in otherTextsToDeactivate)
        {
            if (text != null)
            {
                text.gameObject.SetActive(false);
            }
        }

        // Activate the checkout button
        if (checkoutButton != null)
        {
            checkoutButton.gameObject.SetActive(true);
        }
    }
}
