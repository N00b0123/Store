using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CartController : MonoBehaviour
{
    public static CartController Instance;
    private GameObject cartUI;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI brandText;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private TextMeshProUGUI weigthText;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private RawImage rawImage;

    private List<GameObject> cartUIList = new List<GameObject>();

    private int objIndex;

    private CartListSO cartList;

    private GameObject cartItemTemplate;
    private GameObject scrollUI;

    private ProductSO productSO;
    private PDPListSO pdpListSO;

    private Dictionary<int, ProductSO> productDictionary;

    void Start()
    {
        Instance = this;

        cartUI = GameObject.Find("CartUI");

        cartItemTemplate = GameObject.Find("CartItem");
        scrollUI = GameObject.Find("Panel");
        cartUI.SetActive(false);
        cartItemTemplate.SetActive(false);

        pdpListSO = Resources.Load<PDPListSO>(typeof(PDPListSO).Name);
        cartList = Resources.Load<CartListSO>(typeof(CartListSO).Name);

        //only for not need to remove manually in test
        cartList.list.Clear();

        objIndex = 0;
        productDictionary = new Dictionary<int, ProductSO>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            cartUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            cartUI.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void CreateProductOnCart(PDPListSO pdpList)
    {
        foreach (ProductSO product in pdpList.list)
        {
            if (!cartList.list.Contains(product))
            {

                GameObject itemTemplate = Instantiate(cartItemTemplate, scrollUI.transform);

                cartUIList.Add(itemTemplate);

                Transform nome = itemTemplate.transform.GetChild(2);
                TextMeshProUGUI nomeString = nome.GetComponent<TextMeshProUGUI>();
                nomeString.text = product.productName;

                Transform marca = itemTemplate.transform.GetChild(3);
                TextMeshProUGUI marcaString = marca.GetComponent<TextMeshProUGUI>();
                marcaString.text = product.brand;

                Transform valor = itemTemplate.transform.GetChild(4);
                TextMeshProUGUI valorString = valor.GetComponent<TextMeshProUGUI>();
                valorString.text = (product.value * product.quantity).ToString("F2");

                Transform peso = itemTemplate.transform.GetChild(5);
                TextMeshProUGUI pesoString = peso.GetComponent<TextMeshProUGUI>();
                pesoString.text = product.weigth;

                Transform imagem = itemTemplate.transform.GetChild(6);
                RawImage imagemTextura = imagem.GetComponent<RawImage>();
                imagemTextura.texture = product.renderTexture;

                Transform quantity = itemTemplate.transform.GetChild(7);
                quantity = quantity.transform.GetChild(0);
                TextMeshProUGUI quantityText = quantity.GetComponent<TextMeshProUGUI>();
                quantityText.text = product.quantity.ToString();
                
                //     nameText.text = product.productName;
                //    brandText.text = product.brand;
                //      weigthText.text = product.weigth;
                //     quantityText.text = product.quantity.ToString();
                //     valueText.text = (product.value * product.quantity).ToString();
                //    rawImage.texture = product.renderTexture;


                itemTemplate.SetActive(true);

                //  itemTemplate.GetComponent<RectTransform>().position = scrollUI.GetComponent<RectTransform>().position;

                cartList.list.Add(product);
                productDictionary.Add(objIndex, product);
                objIndex++;
            }
        }
    }

    public void UpdateCart(ProductSO product)
    {
            foreach (KeyValuePair<int, ProductSO> item in productDictionary)
            {
                if (product.productName == item.Value.productName)
                {
                    foreach (GameObject uiTemplate in cartUIList)
                    {
                        var tempTest = uiTemplate.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                        if (tempTest.text == product.productName)
                        {
                            Transform quantity = uiTemplate.transform.GetChild(7);
                            quantity = quantity.transform.GetChild(0);
                            TextMeshProUGUI quantityText = quantity.GetComponent<TextMeshProUGUI>();
                            var tempQuantity = product.quantity + product.quantityPlus;
                            quantityText.text = tempQuantity.ToString();
                            product.quantity = tempQuantity;

                            Transform valor = uiTemplate.transform.GetChild(4);
                            TextMeshProUGUI valorString = valor.GetComponent<TextMeshProUGUI>();
                            valorString.text = (product.value * product.quantity).ToString("F2");

                        }
                    }
                }
            }
    }

    public void RemoveFromCart()
    {
        //just for initialize
        var tempKey = 0;
        var tempUIList = gameObject;
        var tempProduct = productSO;

        var nameButton = EventSystem.current.currentSelectedGameObject.transform;
        foreach (ProductSO product in cartList.list)
        {
            foreach (KeyValuePair<int, ProductSO> item in productDictionary)
            {
                if (product.productName == item.Value.productName)
                {
                    foreach (GameObject uiTemplate in cartUIList)
                    {
                        var removeButton = uiTemplate.transform.GetChild(9).GetComponent<Button>().transform;
                        var tempTest = uiTemplate.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                        if (tempTest.text == product.productName)
                        {
                            if (removeButton == nameButton)
                            {
                                var itemCart = uiTemplate.transform.gameObject;
                                if (itemCart)
                                {
                                    pdpListSO.list.Remove(product);
                                    tempUIList = uiTemplate;
                                    tempKey = item.Key;
                                    tempProduct = product;

                                    Destroy(itemCart);
                                }
                            }
                        }
                    }
                }
            } 
        }
        cartList.list.Remove(tempProduct);
        cartUIList.Remove(tempUIList);
        productDictionary.Remove(tempKey);
    }

}
