using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Src_camera : MonoBehaviour
{
    public float targetAspect = 16f / 9f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            cam.orthographicSize = cam.orthographicSize / scaleHeight;
        }
    }
}
