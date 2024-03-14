using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Behaviours;
using Enemies;
using TMPro;
using Turn_Logic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour

{
    public int maxHealth;

    public int currentHealth;    

    public TextMeshProUGUI healthText;

    public Image healthBarFill;    

    private TurnManager _turnManager;

    private EnemyActor _enemyActor;

    // Start is called before the first frame update
    void Start()
    {
        _turnManager = FindObjectOfType<TurnManager>();
        
    }

    private void OnMouseDown()
    {
        if (DamageButton.isDamageMode)
        {
            TakeDamage(DamageButton.damageAmount);
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        UpdateHealthText();        
    }    
    
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetCurrentHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }
    
    public void SetMaxHealth(int actorHealth)
    {
        maxHealth = actorHealth;
        currentHealth = maxHealth;
        UpdateHealthText();
        UpdateHealthBar();
    }
   

    private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = (float)currentHealth / maxHealth;
    }
    
    private void UpdateHealthText()
    {
        healthText.text = currentHealth + "/" + maxHealth;
    }
}