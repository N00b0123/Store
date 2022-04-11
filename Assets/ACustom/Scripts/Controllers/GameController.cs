using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isCartOpen;
    public bool isCheckoutOpen;

    void Start()
    {
        Raycast raycast = Raycast.Instance;
        raycast.OnObjectSelected += Raycast_OnObjectSelected;
    }

    private void Raycast_OnObjectSelected(object sender, Raycast.OnObjectSelectedArgs e)
    {
        isCartOpen = CartController.Instance.GetCartStatus();
        isCheckoutOpen = CheckoutController.Instance.GetCheckoutStatus();
          if (Input.GetKeyDown(KeyCode.E) && !isCartOpen && !isCheckoutOpen)
          {
              ToolTip.Instance.HideToolTipUI();
              PDPController.Instance.ShowPDP();
          }
    }
}
