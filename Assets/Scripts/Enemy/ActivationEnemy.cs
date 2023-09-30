using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationEnemy : MonoBehaviour
{

  private bool spawning;
  [SerializeField] private GameObject spawningEnemy;




  private void OnTriggerEnter(Collider other)
  {
    if (other.transform.CompareTag("Player") )
    {
      Debug.Log("player");
      StartCoroutine(SpawnTime());

    }

  }


  IEnumerator SpawnTime ()
  {
    spawningEnemy.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    gameObject.SetActive(false);
  }

}
