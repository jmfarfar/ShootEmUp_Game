using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private List<GameObject> bullets = new List<GameObject>();
    [SerializeField] private Transform ship;

    private static BulletPool instance;
    public static BulletPool Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AddBullet(poolSize);
    }

    void AddBullet(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(bulletPref);
            bullet.SetActive(false);
            bullets.Add(bullet);
            bullet.transform.parent = transform;
            bullet.transform.rotation = ship.rotation;
        }
    }

    public GameObject BulletActive()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeSelf)
            {
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }

        AddBullet(1);
        bullets[bullets.Count - 1].SetActive(true);
        return bullets[bullets.Count - 1];
    }
}
