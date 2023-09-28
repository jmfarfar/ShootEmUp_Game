using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]

public class Ship : MonoBehaviour
{

  private HealthSystem healthShip;
  private ShipController shipController;
  private ShipWeaponController shipWeapon;

  public bool isTripleShotActive { get; private set; } 
  public bool isShieldActive { get; private set; } 


  private void Awake()
  {
    healthShip = GetComponent<HealthSystem>();
    shipController = GetComponent<ShipController>();
    shipWeapon = GetComponentInChildren<ShipWeaponController>();    
  }

  
  public  void DealDamage(int damage)
  {
    healthShip.TakeDamage(damage);
  }


  public void Recovery()
  {
    healthShip.RecoverHealth();
  }


  public void SetShieldStatus(bool status) 
  { 
    isShieldActive = status; 
  }


   public void SetSpeedBooster() 
  {
    shipController.SpeedBoostActive();
  }


  public void SetTripleShotStatus(bool status) 
  {
    isTripleShotActive = status;
    if(isTripleShotActive)
    {
      shipWeapon.TripleShotActive();
    }
  }

}
