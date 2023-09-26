using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponController : MonoBehaviour
{

    Vector3 direction;
  public Transform bulletSpawnPoint;
  public float shotSpeed;

   private Ship ship;
    [SerializeField] private GameObject tripleBulletPref; 

    private void Awake()
    {
        ship = GetComponentInParent<Ship>(); 
     }


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
    if (ship.isTripleShotActive)
    {
      Instantiate(tripleBulletPref, transform.position, Quaternion.identity);
    }
    else
    {

      GameObject bullet = BulletPool.Instance.BulletActive();
      if (bullet != null)
      {
        direction = transform.position;
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.forward = direction.normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction.normalized * shotSpeed;
      }
    }
  }
  
  public void TripleShotActive()
  {
    StartCoroutine(TripleShotPowerDownRoutine());
  }


  IEnumerator TripleShotPowerDownRoutine()
  {
    yield return new WaitForSeconds(5.0f);
    ship.SetTripleShotStatus(false);
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
