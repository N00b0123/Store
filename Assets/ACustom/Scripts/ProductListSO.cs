using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ProductList")]
public class ProductListSO : ScriptableObject
{
    public List<ProductSO> list;
}
