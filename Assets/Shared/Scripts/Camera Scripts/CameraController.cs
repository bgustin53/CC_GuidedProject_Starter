using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject FPC;

    // Update is called once per frame
    void Update()
    {
        transform.position = FPC.transform.position;
        transform.rotation = FPC.transform.rotation;
    }
}
