using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool enemyInstance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 20;
    [SerializeField] private GameObject enemyPrefab;
    //private Vector3 minPosition = new Vector3(1f, 1f, 1f);
    //private Vector3 maxPosition = new Vector3(5f, 5f, 5f);

    private void Awake()
    {
        if (enemyInstance == null)
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
        //Vector3 randomPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, Random.insideUnitSphere + this.transform.position, Quaternion.identity);
            enemy.SetActive(true);
            pooledObjects.Add(enemy);
            enemy.transform.parent = transform;
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
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
