using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour {

    public Transform target;
    public float zoomInSpeed;
    public float moveSpeed;
    public float yMinReq, yMaxReq;
    public float xMinReq, xMaxReq;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.deltaTime * moveSpeed);

        if(transform.position.y <= yMinReq)
        {
            transform.position = new Vector3(transform.position.x, yMinReq, transform.position.z);
        }
        else if(transform.position.y >= yMaxReq)
        {
            transform.position = new Vector3(transform.position.x, yMaxReq, transform.position.z);
        }

        if (transform.position.x <= xMinReq)
        {
            transform.position = new Vector3(xMinReq, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= xMaxReq)
        {
            transform.position = new Vector3(xMaxReq, transform.position.y, transform.position.z);
        }
    }
}
