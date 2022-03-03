using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private GameObject mainCamera;
    [SerializeField] private float raycastRange = 5f;
    private GameObject player;

    private GameObject UI;

    private Material mat;
    private RaycastHit hit;
    private Transform lastHitObj;

    void Awake()
    {
        UI = GameObject.Find("image");
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

    // Update is called once per frame
    void Update()
    {
        RaycastHit();
    }

    void RaycastHit()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, raycastRange))
        {
            if (!hit.collider.gameObject.CompareTag("Player"))
            {
                mat = hit.transform.GetComponent<Renderer>().material;
                if (lastHitObj != null)
                {
                    mat.SetFloat("_outlineThickness", 0.89f);
                    UI.SetActive(true);
                }
                lastHitObj = hit.collider.transform;
            }
        }
        else if (lastHitObj)
        { 
            mat = lastHitObj.transform.GetComponent<Renderer>().sharedMaterial;
            mat.SetFloat("_outlineThickness", 0f);
            UI.SetActive(false);
        }
    }
}
