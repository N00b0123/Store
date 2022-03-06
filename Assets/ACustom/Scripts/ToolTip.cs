using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI brandText;
    private TextMeshProUGUI valueText;
    private TextMeshProUGUI weigthText;
    private TextMeshProUGUI expirationText;
    private RawImage renderTexture;


    void Start()
    {
        nameText = transform.Find("nameText").GetComponent<TextMeshProUGUI>();
        brandText = transform.Find("brandText").GetComponent<TextMeshProUGUI>();
        valueText = transform.Find("valueText").GetComponent<TextMeshProUGUI>();
        weigthText = transform.Find("weigthText").GetComponent<TextMeshProUGUI>();
        expirationText = transform.Find("expirationText").GetComponent<TextMeshProUGUI>();
        renderTexture = transform.Find("RawImage").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
