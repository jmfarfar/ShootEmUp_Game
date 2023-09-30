using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    Transform target;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationalDamp = .5f;
    private Rigidbody rb;

    private EnemyLife enemyLife;


    private void Awake()
    {
        enemyLife = GetComponent<EnemyLife>();
        rb = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {

        Turn();
        Move();

    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        rb.velocity = transform.forward * movementSpeed * Time.deltaTime;
        var distance = Vector3.Distance(transform.position, target.position);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            enemyLife.EnemyDamage(5);
        }
    }


}
