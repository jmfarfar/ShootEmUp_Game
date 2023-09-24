using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponController : MonoBehaviour
{

    Vector3 direction;
    public Transform bulletSpawnPoint;
    //public float shotSpeed;
    private void Update()
    {
        // Left click 
        if (Input.GetMouseButtonDown(0))
        {
            Bullets();
        }
    }

    public void Bullets()
    {
        GameObject bullet = BulletPool.Instance.BulletActive();
        if (bullet != null)
        {
            direction = transform.position;
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.forward = transform.forward.normalized;
            //bullet.GetComponent<Rigidbody>().velocity = transform.forward.normalized * shotSpeed;
        }



    }




}

//public class ShipWeaponController : MonoBehaviour
//{
//    private void FixedUpdate()
//    {
//        // Left click 
//        if (Input.GetMouseButtonDown(0))
//        {
//            GameObject bullet = BulletPool.Instance.BulletActive();
//            bullet.transform.SetPositionAndRotation(transform.position, transform.parent.rotation);

//            //bullet.transform.rotation = Quaternion.LookRotation(transform.forward - transform.position);
//        }
//    }
//}
