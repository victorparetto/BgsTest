using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow = null;

    void Start()
    {

    }

    void Update()
    {
        transform.position = objectToFollow.transform.position + (Vector3.forward * -10);
    }
}
