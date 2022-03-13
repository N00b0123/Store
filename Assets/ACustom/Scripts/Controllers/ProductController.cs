using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductController : MonoBehaviour, IProduct
{

    private Material mat;

    void Start()
    {
        Raycast raycast = Raycast.Instance;
        raycast.OnObjectSelected += Raycast_OnObjectSelected;
        raycast.OnObjectUnSelected += Raycast_OnObjectUnSelected;
    }

    private void Raycast_OnObjectUnSelected(object sender, Raycast.OnObjectUnSelectedArgs e)
    {

        mat = e.lastHitObj.transform.GetComponent<Renderer>().material;

        mat.SetFloat("_outlineThickness", 0f);
    }

    private void Raycast_OnObjectSelected(object sender, Raycast.OnObjectSelectedArgs e)
    {
        mat = e.nowHitObj.transform.GetComponent<Renderer>().material;

        //value for spheres
      //  mat.SetFloat("_outlineThickness", 0.55f);

        mat.SetFloat("_outlineThickness", 0.89f);

    }

    public void Selected()
    {

    }

    public void UnSelected()
    {

    }
}
