using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Actions.Lists
{
    [CreateAssetMenu(fileName = "ActionSet", menuName = "ScriptableObjects/ActionSet", order = 2)]
    public class ActionSet : ScriptableObject
    {
        public List<IEnemyAction> ActionList { get; set; } 
    }
}