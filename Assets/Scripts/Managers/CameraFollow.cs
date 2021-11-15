using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float SmoothSpeed; //default 0.125f
    [SerializeField] Vector3 offset;
    void Start()
    {
        transform.position = target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 destination = target.position + offset;
        Vector3 transition = Vector3.Lerp(transform.position, destination, SmoothSpeed);
        transform.position = transition;
    }
}
