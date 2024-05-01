using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraclamp : MonoBehaviour
{
    public Transform targetToFollow;

    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -30, 30), 
            transform.position.y,
            transform.position.z
            );
    }
}
