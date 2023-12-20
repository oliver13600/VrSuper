using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPENDOOR : MonoBehaviour
{
    public Animation animation1;
    public Animation animation2;

    public string animationName; // Add this line
    public string animationName2; // Add this line
    public string animationName3; // Add this line
    public string animationName4; // Add this line
    // Start is called before the first frame update
    void Start()
    {
        doorplay();
    }
    void doorplay()
    {
        Invoke("openDoor", 3.0f);
        Invoke("closeDoor", 15.0f);
    }
    void openDoor()
    {
        animation1.Play(animationName); // Modify this line
        animation2.Play(animationName2); // Modify this line
    }
    
    void closeDoor()
    {
        animation1.Play(animationName3); // Modify this line
        animation2.Play(animationName4); // Modify this line
    }

    
}
