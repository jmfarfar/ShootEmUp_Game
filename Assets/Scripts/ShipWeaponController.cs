using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShipWeaponController : MonoBehaviour
{
    public AudioClip shootClip;
    public AudioMixerGroup shootMixer;

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
                bullet.transform.forward = transform.forward.normalized;
                //bullet.GetComponent<Rigidbody>().velocity = direction.normalized * shotSpeed;
                AudioManager.Instance.PlaySound(shootClip, shootMixer);
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




