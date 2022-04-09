using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PDPController : MonoBehaviour
{
    private GameObject UIDetails;
    private GameObject UIButtons;
    private GameObject UIDetailsNextPage;
    public static PDPController Instance;
    private int quantity;
    [SerializeField] TextMeshProUGUI quantityText;
    private PDPListSO pdpList;
    private bool isEnableAddToCart;
    private bool isPDPOpen;

    private void Start()
    {
        isEnableAddToCart = false;
        isPDPOpen = false;
        Raycast raycast = Raycast.Instance;
        raycast.OnObjectChangeRayPDP += Raycast_OnObjectChangeRayPDP;

        pdpList = Resources.Load<PDPListSO>(typeof(PDPListSO).Name);

        //only for not need to remove manually in test
        pdpList.list.Clear();

        quantity = 1;
        Instance = this;
        UIDetails = GameObject.Find("details");
        UIDetails.SetActive(false);
        UIButtons = GameObject.Find("Buttons");
        UIButtons.SetActive(false);
        UIDetailsNextPage = GameObject.Find("nextPage");
        UIDetailsNextPage.SetActive(false);
    }

    private void Raycast_OnObjectChangeRayPDP(object sender, Raycast.OnObjectChangeRayPDPArgs e)
    {
        if (isEnableAddToCart)
        {
            if (!pdpList.list.Contains(e.productSO))
            {
                e.productSO.quantity = quantity;
                pdpList.list.Add(e.productSO);
                CartController.Instance.CreateProductOnCart(pdpList);
            }
            else
            {
                e.productSO.quantityPlus = quantity;
                CartController.Instance.UpdateCart(e.productSO);
            }
            isEnableAddToCart = false;
        }
    }

    public bool GetPDPStatus()
    {
        return isPDPOpen;
    }

    public void ShowPDP()
    {
        UIDetails.SetActive(true);
        UIButtons.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPDPOpen = true;
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
        isPDPOpen = false;
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
        isEnableAddToCart = true;
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

