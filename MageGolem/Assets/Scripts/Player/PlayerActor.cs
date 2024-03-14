using System;
using System.Collections.Generic;
using System.Linq;
using Auras;
using UnityEngine;
using Enemies.Actions;

namespace Behaviours
{
    public class PlayerActor : MonoBehaviour
    {        
        private List<Aura> _activeAuras = new List<Aura>();
        private PlayerHealth _playerHealth;        
        private AuraBar _auraBar;
        private AuraManager _auraManager;
        private DamageCalculator _damageCalculator;        

        private void Awake()
        {            
            _auraManager = GetComponent<AuraManager>();
            _damageCalculator = GetComponent<DamageCalculator>();
            InitializeAuraBar();            
        }

        private void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
        }

        public void AddAura(Aura auraToAdd)
        {
            _activeAuras = _auraManager.AddAura(auraToAdd);         
        }

        public void DoPlayerTurn()
        {
            //TODO Player Behaviours

            Debug.Log("Player's turn!");
        }

        public void EndPlayerTurn()
        {
            _auraManager.TickDownBuffs();                       
        }

        public void CalculateAndApplyDamage(int damage)
        {
            _playerHealth.TakeDamage(_damageCalculator.CalculateDamageTaken(damage, _activeAuras));

            if (_playerHealth.GetCurrentHealth() > 0) return;
            Debug.Log("Player died!");
            _playerHealth.Reset();
        }

        public void DoDamage(int damage)
        {
          damage = _damageCalculator.CalculateDamageOutput(damage, _activeAuras);           
        }
        
        public void OnMouseDown()
        {
            if (DamageButton.isDamageMode)
            {
                EnemyManager.Instance.DoDamageRequest(DamageButton.damageAmount, ActionTarget.Player, null);
            }
        }

        public void InitializeAuraBar()
        {
            var parentTransform = transform.parent;
            _auraBar = _auraManager.InitializeAuraBar(parentTransform.gameObject);
        }
    }    
}