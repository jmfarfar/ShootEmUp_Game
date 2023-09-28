using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

  [SerializeField]  private float MaxHealthPoints = 100;
  [SerializeField]  private float currentHealthPoints;
  [SerializeField]  private int recoveryPoints = 10;

  private Ship ship;

  public float GetHealth() { return currentHealthPoints; }
  public float GetNormalizedHealth(){ return currentHealthPoints / MaxHealthPoints; }


  private void Start()
  {
    currentHealthPoints = MaxHealthPoints;
        ship = GetComponent<Ship>();  
  }

  public void TakeDamage(float damage)
  {

    if (ship.isShieldActive)
    {
      Debug.Log("Shield Desactivado");
      ship.SetShieldStatus(false);
      return;
    }

    currentHealthPoints -= damage;
    Debug.Log(GetHealth());
    if(currentHealthPoints <1)
    {
      Debug.Log("Player destroyed");
   //   Destroy(this.gameObject);      
    }
  }
  
  public void RecoverHealth()
  {
    currentHealthPoints = (currentHealthPoints + recoveryPoints > MaxHealthPoints) ? MaxHealthPoints : currentHealthPoints + recoveryPoints;
    Debug.Log(GetHealth());

  }
}