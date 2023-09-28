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

            AudioManager.Instance.PlaySound(shootClip, shootMixer);
        }
    }
}


