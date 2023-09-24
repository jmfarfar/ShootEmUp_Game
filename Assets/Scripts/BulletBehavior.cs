using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bulletSpeed = 300f;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rb.velocity = transform.forward * bulletSpeed;

    }

    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
        //transform.position = transform.parent.position;
        //transform.localPosition = Vector3.zero; 
        //transform.localRotation = Quaternion.identity;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        
    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

}
