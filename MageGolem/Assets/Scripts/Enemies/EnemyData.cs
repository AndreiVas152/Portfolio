using System.Collections;
using System.Collections.Generic;
using Enemies.Actions;
using Enemies.Actions.Lists;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{

    public int id;
    public string enemyName;
    public int maxHealth;
    public Sprite enemySprite;
    public float spriteScale;
    public ActionSet Actions;
}
