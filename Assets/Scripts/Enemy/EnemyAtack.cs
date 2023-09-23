using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{

  private Transform playerPosition;

  Vector3 hitPosition;


  public Transform bulletSpawnPoint;
  public GameObject bulletPrefab;
  Vector3 direction;
  public float shotSpeed;

  [SerializeField]
  private float _fireRate = 0.5f;
    [SerializeField]
  private float _canFire = -1f;


void Start()
{
    playerPosition = GameObject.FindWithTag("Player").transform;
}

  void Update()
  {
    InFront();
    HaveLineOfSight();
    if(InFront() && HaveLineOfSight() && Time.time > _canFire )
    {
       Bullets(hitPosition);
    }
  }


  bool InFront()
  {
    Vector3 directionToTarget = playerPosition.position - transform.position;
    float angle = Vector3.Angle(transform.forward, directionToTarget);
//if in range
    if(angle < 90 )
    {
      Debug.DrawLine(transform.position, playerPosition.position, Color.yellow);
      return true;
    }
    Debug.DrawLine(transform.position, playerPosition.position, Color.green);
    return false;
  }

  bool HaveLineOfSight()
  {
      RaycastHit hit;
      direction = playerPosition.position - transform.position;

      if(Physics.Raycast(transform.position, direction, out hit, 300))
      {
        if(hit.transform.CompareTag("Player"))
        {
          Debug.DrawRay(transform.position, direction, Color.red);
          hitPosition = hit.transform.position;
          return true;
        }
      }
      return false;
  }

    void FireLaser()
    {
        Bullets(hitPosition);
    }


public void Bullets(Vector3 targetPosition)
  {
          _canFire = Time.time + _fireRate;
    GameObject bullet = BulletPoolManager.instance.GetPooledObject();
    if(bullet != null)
    {
      bullet.transform.position = bulletSpawnPoint.position;
      bullet.transform.forward = direction.normalized;     
     bullet.GetComponent<Rigidbody>().velocity=direction.normalized * shotSpeed;      
    }



  }




}