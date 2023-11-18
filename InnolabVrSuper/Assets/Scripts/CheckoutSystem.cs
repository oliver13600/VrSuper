using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CheckoutSystem : MonoBehaviour
{
    public BoxCollider checkoutCollider;
    public TextMeshPro checkoutText;
    public TextMeshPro welcomeText;
    public TextMeshPro byeText;
    public TextMeshPro scanText;
    public BoxCollider scanningCollider;
    public AudioSource beepSound;
    public AudioSource thankYouSound;
    public AudioSource welcomeSound;
    public Button checkoutbutton;
    public Animation animation1;
    public Animation animation2;

    public string animationName; // Add this line
    public string animationName2; // Add this line
    bool welcomeplayed = false;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the checkout area
        if (other.gameObject.tag == "Player") // Make sure your player GameObject has the tag "Player"
        {
            checkoutText.gameObject.SetActive(true);
            welcomeText.gameObject.SetActive(false);
            scanningCollider.gameObject.SetActive(true);
            
            if (!welcomeplayed)
            {
                welcomeSound.Play();
                welcomeplayed = true;
            }
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the checkout area
        if (other.gameObject.tag == "Player")
        {
            checkoutText.gameObject.SetActive(false);
            welcomeText.gameObject.SetActive(true);
            scanningCollider.gameObject.SetActive(false);
            checkoutbutton.gameObject.SetActive(false);
            
            
        }
    }

    public void Checkout()
    {
        thankYouSound.Play();
        checkoutText.gameObject.SetActive(false);
        scanningCollider.gameObject.SetActive(false);
        checkoutbutton.gameObject.SetActive(false);
        scanText.gameObject.SetActive(false);
        byeText.gameObject.SetActive(true);
        animation2.Play(animationName); // Modify this line
        animation1.Play(animationName); // Modify this line
        Invoke("Reset", 3f);
    }

    private void Reset()
    {
        byeText.gameObject.SetActive(false);
        welcomeText.gameObject.SetActive(true);
    }
}
