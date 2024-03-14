using System.Collections.Generic;
using Auras;
using Behaviours;
using CardScripts.Database;
using Enemies;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

namespace CardScripts
{
    public class CardExecutor : MonoBehaviour
    {
        private Card _card;
        private EnemyManager _enemyManager;

        private void Awake()
        {
            _enemyManager = EnemyManager.Instance;
        }

        public void PlayCard(Card card, [CanBeNull] GameObject target)
        {
            var auraList = card.auraList;
            var player = _enemyManager.player;

            if (auraList.Count > 0)
            {
                switch (card.cardTarget)
                {
                    case CardTarget.SingleTargetEnemy:
                        ApplyAurasToEnemy(auraList, target);
                        break;

                    case CardTarget.Self:
                        ApplyAurasToPlayer(auraList);
                        break;

                    case CardTarget.AllEnemies:
                    {
                        var enemies = _enemyManager.enemies;
                        foreach (var enemy in enemies)
                            ApplyAurasToEnemy(auraList, enemy);
                    }
                        break;

                    case CardTarget.RandomEnemy:
                    {
                        ApplyAurasToEnemy(auraList, _enemyManager.enemies[Randomize()]);
                    }
                        break;

                    case CardTarget.SingleTargetAny:
                        if (target == null) break;
                        if (target.GetComponentInChildren<EnemyActor>() != null)
                        {
                            ApplyAurasToEnemy(auraList, target);
                        }
                        else
                        {
                            ApplyAurasToPlayer(auraList);
                        }

                        break;

                    case CardTarget.Everything:
                    {
                        var enemies = _enemyManager.enemies;
                        foreach (var enemy in enemies)
                            ApplyAurasToEnemy(auraList, enemy);
                        ApplyAurasToPlayer(auraList);
                    }
                        break;
                }
            }

            if (card.power == 0) return;

            switch (card.cardTarget)
            {
                case CardTarget.SingleTargetEnemy:
                    if (target == null) break;
                    _enemyManager.TakeDamageRequest(card.power, target.GetComponentInChildren<EnemyActor>());
                    break;

                case CardTarget.Self:
                    player.CalculateAndApplyDamage(card.power);
                    break;

                case CardTarget.AllEnemies:
                {
                    var enemies = _enemyManager.enemies;
                    foreach (var enemy in enemies)
                        _enemyManager.TakeDamageRequest(card.power, enemy.GetComponentInChildren<EnemyActor>());                    
                }
                    break;

                case CardTarget.RandomEnemy:
                {
                    _enemyManager.TakeDamageRequest(card.power, _enemyManager.enemies[Randomize()].GetComponentInChildren<EnemyActor>());
                }
                    break;
                
                case CardTarget.SingleTargetAny:
                    if (target == null) break;
                    if (target.GetComponentInChildren<EnemyActor>() != null)
                    {
                        _enemyManager.TakeDamageRequest(card.power, target.GetComponentInChildren<EnemyActor>());
                    }
                    else
                    {
                        player.CalculateAndApplyDamage(card.power);
                    }

                    break;
                
                case CardTarget.Everything:
                {
                    var enemies = _enemyManager.enemies;
                    foreach (var enemy in enemies)
                        _enemyManager.TakeDamageRequest(card.power, enemy.GetComponentInChildren<EnemyActor>());
                    player.CalculateAndApplyDamage(card.power);
                }
                    break;
                
                default:
                    break;
            }
        }

        private void ApplyAurasToEnemy(List<AuraEffect> auraList, GameObject target)
        {
            for (var i = auraList.Count - 1; i >= 0; i--)
            {
                _enemyManager.AuraReceiveRequest(AuraFactory.GetAura(auraList[i]),
                    target.GetComponentInChildren<EnemyActor>());
            }
        }

        private void ApplyAurasToPlayer(List<AuraEffect> auraList)
        {
            var player = _enemyManager.player;
            for (var i = auraList.Count - 1; i >= 0; i--)
            {
                player.AddAura(AuraFactory.GetAura(auraList[i]));
            }
        }

        private int Randomize()
        {
            var random = new Random();
            var randomEnemyIndex = random.Next(_enemyManager.enemies.Count);
            return randomEnemyIndex;
        }
    }
}