using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Vector3 movementAxis;
    public float distance;

    private Vector3 openPos;
    private Vector3 closedPos;


    // Start is called before the first frame update
    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos - (movementAxis * distance);
    }

    public void CloseGate()
    {
        transform.Translate(movementAxis * distance * -1f, Space.World);
    }

    public void OpenGate()
    {
        transform.Translate(movementAxis * distance, Space.World);
    }

}
