using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            var direction = worldPos - transform.position;
            direction.Normalize();

            var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = direction;
        }
    }
}
