using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        var worldPos = cam.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        var direction = worldPos - transform.position;
        direction.Normalize();//makes the vector have values between -1 and 1
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
