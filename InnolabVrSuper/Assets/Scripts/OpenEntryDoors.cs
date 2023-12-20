using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEntryDoors : MonoBehaviour
{
    public Animation animation1;
    public Animation animation2;

    public string animationName; // Add this line
    public string animationName2; // Add this line
    bool isPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            if (!isPlayed)
            {
                animation2.Play(animationName); // Modify this line
                animation1.Play(animationName); // Modify this line
                isPlayed = true;
            }
        }
    }
}
