using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    private int _maxHealth = 100;

    private int _currentHealth;

    public Image healthBarFill;

    public TextMeshProUGUI healthText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _currentHealth = _maxHealth;
        }
        else
        {
            Destroy(gameObject);            
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        UpdateHealthText();
        UpdateHealthBar();
    }    

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        UpdateHealthBar();
        UpdateHealthText();

        if (_currentHealth < 0)
        {
            //TODO GAME OVER
        }
    }    

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetCurrentHealthPercentage()
    {
        return (float)_currentHealth / _maxHealth;
    }
    
    private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = (float)_currentHealth / _maxHealth;
    }

    private void UpdateHealthText()
    {
        healthText.text = _currentHealth + "/" + _maxHealth;
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
        UpdateHealthBar();
        UpdateHealthText();
    }
}
