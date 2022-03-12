using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Product")]
public class ProductSO : ScriptableObject
{
    public string productName;
    public string brand;
    public string value;
    public string weigth;
    public string manufactureDate;
    public string expirationDate;
    public string ingredients;
    public string allergies;
    public int stock;
    public Transform model3D;
    public RenderTexture renderTexture;
}
