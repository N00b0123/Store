using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public static Raycast Instance { get; private set; }

    private GameObject mainCamera;
    [SerializeField] private float raycastRange = 5f;
    private GameObject player;

    private GameObject UI;

    private Material mat;
    private RaycastHit hit;
    private Transform lastHitObj;

    private SOLink productLink;
    private ProductSO productSO;

    public event EventHandler<OnObjectChangeRayArgs> OnObjectChangeRay;

    public class OnObjectChangeRayArgs : EventArgs
    {
        public ProductSO productSO;
    }

    void Awake()
    {
        Instance = this;

        UI = GameObject.Find("toolTip");
        UI.SetActive(false);


        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

    }

    void Update()
    {
        RaycastHit();
    }

    //analisar para substituir raycast por raycastAll
    //analisar substituir verficaçao de qual objeto esta ativo com eventos
    void RaycastHit()
    {

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, raycastRange))
        {

            if (!hit.collider.gameObject.CompareTag("Player"))
            {
                mat = hit.transform.GetComponent<Renderer>().material;
                if (lastHitObj != null)
                {
                    productLink = hit.collider.GetComponent<SOLink>();
                    productSO = productLink.GetSO();

                    mat.SetFloat("_outlineThickness", 0.89f);
                    UI.SetActive(true);
                    //   ToolTip.ShowToolTip_Static();
                    OnObjectChangeRay?.Invoke(this, new OnObjectChangeRayArgs { productSO = productSO });
                }
                lastHitObj = hit.collider.transform;
            }
        }
        else if (lastHitObj)
        {
            mat = lastHitObj.transform.GetComponent<Renderer>().sharedMaterial;
            mat.SetFloat("_outlineThickness", 0f);
            UI.SetActive(false);
            //   ToolTip.HideToolTip_Static();
        }
    }

}
