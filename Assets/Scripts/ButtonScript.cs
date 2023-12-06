using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game;
public class ButtonScript : MonoBehaviour
{
    public GateScript gateController;

    void OnTriggerEnter2D(Collider2D collider)
    {
        gateController.OpenGate();
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        gateController.CloseGate();
    }
}
