using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PDPController : MonoBehaviour
{
    private GameObject UIDetails;
    public static PDPController Instance;
    private int quantity;
    [SerializeField] TextMeshProUGUI quantityText;

    private void Start()
    {
        quantity = 1;
        Instance = this;
        UIDetails = GameObject.Find("details");
        UIDetails.SetActive(false);
    }

    public void ShowPDP()
    {
        UIDetails.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void HidePDP()
    {
        quantity = 1;
        quantityText.text = quantity.ToString();
        UIDetails.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void NextPage()
    {
        Debug.Log("Next Page");
    }

    public void AddToWishList()
    {
        Debug.Log("Add To WishList");
    }

    public void AddToCart()
    {
        //disparar evento passando o produto e a quantidade
        Debug.Log($"Add To Cart: {quantity} ");
    }

    public void IncreaseQuantity()
    {
        quantity++;
        quantityText.text = quantity.ToString();
    }

    public void DecreaseQuantity()
    {
        if(quantity > 1)
        {
            quantity--;
        }

        quantityText.text = quantity.ToString();
    }
}

