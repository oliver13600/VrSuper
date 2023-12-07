using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplay : MonoBehaviour
{
    public ProductInfo productInfo;
    // Start is called before the first frame update

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text priceText;

    void Start()
    {
        nameText.text = productInfo.productName;
        descriptionText.text = productInfo.productDescription;
        priceText.text = productInfo.productPrice.ToString();
    }

    private void Update()
    {
        nameText.text = productInfo.productName;
        descriptionText.text = productInfo.productDescription;
        priceText.text = productInfo.productPrice.ToString();
    }
}
