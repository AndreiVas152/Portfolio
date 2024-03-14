using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Animation;
using Auras;
using Behaviours;
using Enemies.Actions;
using Enemies.Actions.Common;
using Turn_Logic;
using UnityEngine;

namespace Enemies
{
    public class EnemyActor : MonoBehaviour
    {
        private AuraManager _auraManager;
        private DamageCalculator _damageCalculator;
        private List<Aura> _activeAuras = new();
        private IEnemyAction _nextAction;
        private IEnemyAction _previousAction;
        public EnemyData enemyData;        
        public EnemyHealth enemyHealth;
        public EnemyIntent intentBox;
        public AuraBar auraBar;
        public GameObject actionEffect;
        public SpriteRenderer spriteRenderer;
        public EnemyIntent enemyIntent;


        private void Awake()
        {
            
        }

        private void Start()
        {
            _auraManager = GetComponent<AuraManager>();
            _damageCalculator = GetComponent<DamageCalculator>();
            InitializeAuraBar();            
            enemyHealth.SetMaxHealth(enemyData.maxHealth);
            spriteRenderer.sprite = enemyData.enemySprite;
            spriteRenderer.transform.localScale = new Vector3(enemyData.spriteScale, enemyData.spriteScale, 1);
            _nextAction = enemyData.Actions.ActionList[Random.Range(0, enemyData.Actions.ActionList.Count)];            
            enemyIntent = intentBox.GetComponent<EnemyIntent>();
            enemyIntent.SetIntent(_nextAction);
        }

        public IEnumerator DoEnemyTurn()
        {
            _auraManager.TickDownBuffs();
            _nextAction.Execute(this);

            _previousAction = _nextAction;

            while (_nextAction == _previousAction)
            {
                _nextAction = enemyData.Actions.ActionList[Random.Range(0, enemyData.Actions.ActionList.Count)];
            }            
            
            actionEffect.GetComponent<PowEffect>().Show();

            yield return new WaitForSeconds(1f);

            Debug.Log("Enemy's turn!");
        }

        public void ShowIntent()
        {
            if (_nextAction != null)
            {
                enemyIntent.SetIntent(_nextAction);
            }            
        }

        public void CalculateAndApplyDamage(int damage)
        {            
            enemyHealth.TakeDamage((_damageCalculator.CalculateDamageTaken(damage, _activeAuras)));
            if (enemyHealth.GetCurrentHealth() <= 0) Die();
            
        }
        
        public int DoDamage(int damage)
        {
           return _damageCalculator.CalculateDamageOutput(damage, _activeAuras);
        }
        
        public void AddAura(Aura auraToAdd)
        {
            _activeAuras = _auraManager.AddAura(auraToAdd);
            auraBar.RefreshIconDisplays();
        }

        private void Die()
        {            
            Destroy(gameObject);
            Destroy(enemyHealth);
            Destroy(auraBar);            
            EnemyManager.Instance.UnregisterEnemy(gameObject);
        }
        
        public void OnMouseDown()
        {
            if (!DamageButton.isDamageMode) return;
            EnemyManager.Instance.DoDamageRequest(DamageButton.damageAmount, ActionTarget.Self, this);
            EnemyManager.Instance.AuraApplyRequest(AuraFactory.GetAura(AuraEffect.LessMultiplierDefense), ActionTarget.Self, this);
        }
        
        public void InitializeAuraBar()
        {
            var parentTransform = transform.parent;
            auraBar = _auraManager.InitializeAuraBar(parentTransform.gameObject);
        }
    }
}