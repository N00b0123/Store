using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private static ToolTip instance;
    [SerializeField] private ProductSO productSO;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        
    }

    private void ShowToolTip()
    {
        gameObject.SetActive(true);
    }

    private void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowToolTip_Static()
    {
        instance.ShowToolTip();
    }

    public static void HideToolTip_Static()
    {
        instance.HideToolTip();
    }
}
