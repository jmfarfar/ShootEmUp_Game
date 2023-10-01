using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [SerializeField] private HealthSystem healthSystem;

    void Update()
    {
        healthBar.fillAmount = healthSystem.GetNormalizedHealth();
    }    
}
