using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiController : MonoBehaviour
{

    public InputAction uiControlls;
    public GameObject ui;
    public bool isPressed = false;
    public float activationCooldown = 0.5f; // Cooldown time in seconds
    private bool canActivate = true;
    private Coroutine cooldownCoroutine;

    // Start is called before the first frame update

    public void OnEnable()
    {
        uiControlls.Enable();
    }

    public void OnDisable()
    {
        uiControlls.Disable();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isButtonPressed = uiControlls.ReadValue<float>() > 0.5f;

        if (isButtonPressed && canActivate)
        {
            ui.SetActive(!ui.activeSelf); // Toggle the UI activation
            canActivate = false;

            if (cooldownCoroutine != null)
                StopCoroutine(cooldownCoroutine);

            cooldownCoroutine = StartCoroutine(ActivationCooldown());
        }
    }

    private IEnumerator ActivationCooldown()
    {
        yield return new WaitForSeconds(activationCooldown);
        canActivate = true;
    }
}