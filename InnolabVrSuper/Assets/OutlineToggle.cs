using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineToggle : MonoBehaviour
{
    public XRGrabInteractable interactable;
    public Outline outlineScript;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        outlineScript = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        interactable.onSelectEntered.AddListener(OnSelect);
        interactable.onSelectExited.AddListener(OnDeselect);
    }

    private void OnDisable()
    {
        interactable.onSelectEntered.RemoveListener(OnSelect);
        interactable.onSelectExited.RemoveListener(OnDeselect);
    }

    private void OnSelect(XRBaseInteractor interactor)
    {
        outlineScript.enabled = true;
    }
    private void OnDeselect(XRBaseInteractor interactor)
    {
        outlineScript.enabled = false;
    }
}