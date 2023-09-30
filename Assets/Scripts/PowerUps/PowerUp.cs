using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    SHIELD,
    VELOCITY,
    TRIPLESHOT,
    HEALTH,
}

public class PowerUp : MonoBehaviour
{

    public PowerUpType powerUpType;

    public AudioClip shieldActivateSound;
    public AudioClip velocityBurstSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Ship ship = other.transform.GetComponent<Ship>();
            switch (powerUpType)
            {
                case PowerUpType.SHIELD:
                    Debug.Log("SHIELD Activado");
                    AudioManager.Instance.PlaySound(shieldActivateSound);
                    ship.SetShieldStatus(true);
                    break;
                case PowerUpType.VELOCITY:
                    Debug.Log("VELOCITY avtivada");
                    AudioManager.Instance.PlaySound(velocityBurstSound);
                    ship.SetSpeedBooster();
                    break;
                case PowerUpType.TRIPLESHOT:
                    Debug.Log("TRIPLE SHOT activado");
                    ship.SetTripleShotStatus(true);
                    break;
                case PowerUpType.HEALTH:
                    Debug.Log("RECOVER Life");
                    ship.Recovery();
                    break;
                default:
                    break;
            }

            SelfDestroy();
        }
    }


    public void SelfDestroy()

    {
        Destroy(gameObject);
    }

}
