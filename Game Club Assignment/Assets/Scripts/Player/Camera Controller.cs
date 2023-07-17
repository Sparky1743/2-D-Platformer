using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playertransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playertransform.position.x, playertransform.position.y, transform.position.z);
    }
}