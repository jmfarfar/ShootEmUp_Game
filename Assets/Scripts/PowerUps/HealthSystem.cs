using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public AudioClip shieldDeactivateSound;
    [SerializeField] private float MaxHealthPoints = 100;
    [SerializeField] private float currentHealthPoints;
    [SerializeField] private int recoveryPoints = 10;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;

    private Ship ship;

    public float GetHealth() { return currentHealthPoints; }
    public float GetNormalizedHealth() { return currentHealthPoints / MaxHealthPoints; }


    private void Start()
    {
        currentHealthPoints = MaxHealthPoints;
        ship = GetComponent<Ship>();
    }

    public void TakeDamage(float damage)
    {

        if (ship.isShieldActive)
        {
            AudioManager.Instance.PlaySound(shieldDeactivateSound);
            Debug.Log("Shield Desactivado");
            ship.SetShieldStatus(false);
            return;
        }

        currentHealthPoints -= damage;
        AudioManager.Instance.PlaySound(hitSound);
        Debug.Log(GetHealth());
        if (currentHealthPoints < 1)
        {
            Debug.Log("Player destroyed");
            StartCoroutine(DeathSound());
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void RecoverHealth()
    {
        currentHealthPoints = (currentHealthPoints + recoveryPoints > MaxHealthPoints) ? MaxHealthPoints : currentHealthPoints + recoveryPoints;
        Debug.Log(GetHealth());

    }

    IEnumerator DeathSound()
    {
        AudioManager.Instance.PlaySound(deathSound);
        yield return new WaitForSeconds(2f);
    }
}