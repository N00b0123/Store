using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PDPController : MonoBehaviour
{
    private GameObject UIDetails;
    private GameObject UIButtons;
    private GameObject UIDetailsNextPage;
    public static PDPController Instance;
    private int quantity;
    [SerializeField] TextMeshProUGUI quantityText;

    private void Start()
    {
        quantity = 1;
        Instance = this;
        UIDetails = GameObject.Find("details");
        UIDetails.SetActive(false);
        UIButtons = GameObject.Find("Buttons");
        UIButtons.SetActive(false);
        UIDetailsNextPage = GameObject.Find("nextPage");
        UIDetailsNextPage.SetActive(false);
        
    }

    public void ShowPDP()
    {
        UIDetails.SetActive(true);
        UIButtons.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void HidePDP()
    {
        quantity = 1;
        quantityText.text = quantity.ToString();
        UIDetails.SetActive(false);
        UIDetailsNextPage.SetActive(false);
        UIButtons.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void NextPage()
    {
        UIDetails.SetActive(false);
        UIButtons.SetActive(true);
        UIDetailsNextPage.SetActive(true);
    }

    public void BackFistPagePDP()
    {
        UIButtons.SetActive(true);
        UIDetailsNextPage.SetActive(false);
        UIDetails.SetActive(true);
    }

    public void AddToWishList()
    {
        Debug.Log($"Add To WishList: {quantity} ");
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

