using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckoutController : MonoBehaviour
{
    public static CheckoutController Instance;
    [SerializeField] private TextMeshProUGUI totalValue;
    private float valueProduct;
    private CartListSO cartList;
    private List<float> tempListValue;
    private int totalItens = 0;

    private void Start()
    {
        Instance = this;

        valueProduct = 0f;

        cartList = Resources.Load<CartListSO>(typeof(CartListSO).Name);

        

        if (totalValue.text == "0,00")
        {
            totalValue.gameObject.SetActive(false);
        }
        else
        {
            totalValue.gameObject.SetActive(true);
        }

    }

    private void Update()
    {
        
    }

    public void UpdateValue()
    {
        int i = 0;
        totalItens = CartController.Instance.GetCartListAmmount();
        tempListValue = new List<float>(new float[totalItens]);

        foreach (var item in cartList.list)
        {
            tempListValue[i] = item.quantity * item.value;
            i++;
        }

        foreach(var val in tempListValue)
        {
            valueProduct += val;
        }
 
        totalValue.text = valueProduct.ToString("F2");

        bool isRemoved = CartController.Instance.GetRemovedStatus();

        if (isRemoved)
        {
            var valueToRemove = CartController.Instance.GetItemValueToRemove();
            valueProduct -= valueToRemove;
            totalValue.text = valueProduct.ToString("F2");
        }

        valueProduct = 0f;
        tempListValue.Clear();

        if (totalValue.text == "0,00")
        {
            totalValue.gameObject.SetActive(false);
        }
        else
        {
            totalValue.gameObject.SetActive(true);
        }
    }
}
