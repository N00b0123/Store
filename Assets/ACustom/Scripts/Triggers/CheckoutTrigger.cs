using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckoutController.Instance.ShowCheckout();
        }
    }
}
