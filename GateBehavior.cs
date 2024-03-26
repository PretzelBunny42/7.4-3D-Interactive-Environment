using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player enter " + other.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player enter: opening");
            gameObject.BroadcastMessage("OpenGate");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exit " + other.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Exit: closing");
            gameObject.BroadcastMessage("CloseGate");
        }
    }




}
