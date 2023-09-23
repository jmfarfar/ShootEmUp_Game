using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
  public static BulletPoolManager instance;
  private List<GameObject> pooledObjects = new List<GameObject>();
  private int amountToPool = 20;
  [SerializeField] private GameObject bulletPrefab;


  private void Awake()
  {
    if(instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }


  void Start()
  {
    AddBullet(amountToPool);
  }


  void AddBullet(int poolSize)
  {
    for(int i =0; i<poolSize; i++)
    {
      GameObject bullet = Instantiate(bulletPrefab);
      bullet.SetActive(false);
      pooledObjects.Add(bullet);
      bullet.transform.parent = transform;
    }
  }


  public GameObject GetPooledObject()
  {
    for(int i =0; i< pooledObjects.Count; i++)
    {
      if(!pooledObjects[i].activeInHierarchy)
      {
        pooledObjects[i].SetActive(true);
        return pooledObjects[i];
      }
    }
    AddBullet(1);
    pooledObjects[pooledObjects.Count - 1].SetActive(true);
    return pooledObjects[pooledObjects.Count - 1];
  }
  
  
}
