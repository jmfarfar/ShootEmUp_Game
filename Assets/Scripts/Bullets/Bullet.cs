using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


private void OnCollisionEnter(Collision other) 
{
  if(other.transform.CompareTag("Player"))
  {
    Debug.Log("Le pegó al player");
    gameObject.SetActive(false);
  }
  else if(other.transform.CompareTag("Asteroid"))
  {
    Debug.Log("Le pegó a un asteroide");
    gameObject.SetActive(false);    
  }  
}


}
