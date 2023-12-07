using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductInfo", menuName = "new Product Info")]
public class ProductInfo : ScriptableObject
{
    public string productName;
    public string productDescription;
    public float productPrice;
}
