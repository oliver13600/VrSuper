using System.Linq;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    public int FPS { get; private set; }
    public TextMeshPro displayCurrent;
    private int[] averageArr = new int[72];
    int index = 0;


    public void Update()
    {
        int current = (int)(1f / Time.deltaTime);
        averageArr[index++] = current;
        if (index == 72)
        {
            index = 0;
        }
        if (Time.frameCount % 5 == 0)
        {
            displayCurrent.text = averageArr.Average().ToString() + " FPS";
        }


    }
}
