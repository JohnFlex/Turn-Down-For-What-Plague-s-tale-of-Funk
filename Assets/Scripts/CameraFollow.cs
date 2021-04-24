using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectToFollow;

    public Vector3 offset;

    void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}
