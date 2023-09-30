using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float currentHealthPoints;
    [SerializeField] private AudioClip enemyDeathSound;

    public void EnemyDamage(float damage)
    {
        currentHealthPoints -= damage;

        if (currentHealthPoints <= 0)
        {
            Debug.Log("Enemy destroyed");
            StartCoroutine(PlayEnemyDeathSound());
            Destroy(gameObject);
        }
    }

    IEnumerator PlayEnemyDeathSound()
    {
        AudioManager.Instance.PlaySound(enemyDeathSound);
        yield return new WaitForSeconds(1f);
    }
}
