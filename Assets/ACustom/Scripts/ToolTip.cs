using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public static ToolTip Instance;

    private GameObject UI;
    private GameObject UIDetails;

    private void Start()
    {
        Instance = this;

        UI = GameObject.Find("toolTip");
        UIDetails = GameObject.Find("details");
        UI.SetActive(false);
        UIDetails.SetActive(false);
    }

    public void ShowToolTipUI()
    {
        UI.SetActive(true);
    }

    public void HideToolTipUI()
    {
        UI.SetActive(false);
    }


    public void ShowToolTipPDP()
    {
        UIDetails.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void HideToolTipPDP()
    {
        UIDetails.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

}
