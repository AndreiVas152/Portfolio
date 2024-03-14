using System;
using System.Collections;
using System.Collections.Generic;
using Auras;
using Behaviours;
using Enemies;
using Enemies.Actions;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public GameObject enemyPrefab;
    public PlayerActor player;
    public Canvas worldSpaceCanvas;
    public List<GameObject> enemies = new();
    public GameObject enemy;
    public EnemyData enemyData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public void DoDamageRequest(int damage, ActionTarget target, [CanBeNull] EnemyActor source)
    {
        damage = source.DoDamage(damage);
        switch (target)
        {
            case ActionTarget.Player:
                player.CalculateAndApplyDamage(damage);
                break;
            
            case ActionTarget.Self:
                
                source.CalculateAndApplyDamage(damage);
                break;
            
            case ActionTarget.Group:
                foreach (var t in enemies)
                {
                    t.GetComponent<EnemyActor>().CalculateAndApplyDamage(damage);
                }

                break;
            
            case ActionTarget.Friendly:
                enemies[Random.Range(0, enemies.Count)].GetComponent<EnemyActor>().CalculateAndApplyDamage(damage);
                break;
            
            default:
                break;
        }
    }

    public void TakeDamageRequest(int damage, EnemyActor target)
    {
        target.CalculateAndApplyDamage(damage);
    }

    public void SpawnEnemies(List<GameObject> enemyLocations)
    {
        foreach (var location in enemyLocations)
        {
            enemy = Instantiate(enemyPrefab, location.transform.position, Quaternion.identity, parent: worldSpaceCanvas.transform);
            enemy.GetComponent<EnemyActor>().enemyData = enemyData;
            enemies.Add(enemy);            
        }
    }
    
    public void SetPlayer(PlayerActor player)
    {
        this.player = player;
    }

    public void AuraApplyRequest(Aura aura, ActionTarget target, EnemyActor source)
    {
        switch (target)
        {
            case ActionTarget.Player:
                
                player.AddAura(aura);
                break;
            
            case ActionTarget.Self:
                source.AddAura(aura);
                break;
            
            case ActionTarget.Group:
                foreach (var t in enemies)
                {
                    t.GetComponent<EnemyActor>().AddAura(aura);
                }

                break;
            
            case ActionTarget.Friendly:
                enemies[Random.Range(0, enemies.Count)].GetComponent<EnemyActor>().AddAura(aura);
                break;
            
            default:
                break;
        }        
    }
    
    public void AuraReceiveRequest(Aura aura, EnemyActor target)
    {
        target.AddAura(aura);
    }
}