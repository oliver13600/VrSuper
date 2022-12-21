using UnityEngine;

public class Item : MonoBehaviour
{
    // The description of the item
    public string description;

    // A method to use the item
    public virtual void Use()
    {
        // Do something with the item (e.g. apply a power-up, solve a puzzle, etc.)
        Debug.Log("Using item: " + gameObject.name);
    }
}