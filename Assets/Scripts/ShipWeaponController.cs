using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponController : MonoBehaviour
{
    private void Update()
    {
        // Left click 
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = BulletPool.Instance.BulletActive();
            bullet.transform.SetPositionAndRotation(transform.position, transform.parent.rotation);
        }
    }
}
