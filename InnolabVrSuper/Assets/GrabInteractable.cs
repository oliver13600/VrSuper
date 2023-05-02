using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabInteractable : MonoBehaviour
{
    public Shoppingcart shoppingCart;

    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    [System.Obsolete]
    private void OnEnable()
    {
        interactable.onFirstHoverEntered.AddListener(AddToCart);
        interactable.onLastHoverExited.AddListener(RemoveFromCart);
    }

    [System.Obsolete]
    private void OnDisable()
    {
        interactable.onFirstHoverEntered.RemoveListener(AddToCart);
        interactable.onLastHoverExited.RemoveListener(RemoveFromCart);
    }

    private void AddToCart(XRBaseInteractor interactor)
    {
        shoppingCart.AddItemToCart();
    }
    private void RemoveFromCart(XRBaseInteractor interactor)
    {
        shoppingCart.RemoveItemFromCart();
    }
}
