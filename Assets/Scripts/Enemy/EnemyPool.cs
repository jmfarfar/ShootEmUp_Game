using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
  public static EnemyPool enemyInstance;  
  private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField]  private int amountToPool = 20;
  [SerializeField] private GameObject enemyPrefab;

  private void Awake()
  {
    if(enemyInstance == null)
    {
      enemyInstance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }


  void Start()
  {
    AddEnemy(amountToPool);
  }


  void AddEnemy(int poolSize)
  {
    for(int i =0; i<poolSize; i++)
    {
      GameObject enemy = Instantiate(enemyPrefab, Random.insideUnitSphere, Quaternion.identity);
      enemy.SetActive(true);
      pooledObjects.Add(enemy);
      enemy.transform.parent = transform;
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
    AddEnemy(1);
    pooledObjects[pooledObjects.Count - 1].SetActive(true);
    return pooledObjects[pooledObjects.Count - 1];
  }
  
  
}
