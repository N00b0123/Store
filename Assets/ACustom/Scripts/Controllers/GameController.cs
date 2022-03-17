using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Raycast raycast = Raycast.Instance;
        raycast.OnObjectSelected += Raycast_OnObjectSelected;
    }

    private void Raycast_OnObjectSelected(object sender, Raycast.OnObjectSelectedArgs e)
    {
          if (Input.GetKeyDown(KeyCode.E))
          {
              ToolTip.Instance.HideToolTipUI();
              PDPController.Instance.ShowPDP();
          }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
