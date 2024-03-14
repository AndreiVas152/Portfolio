using System.Collections.Generic;
using Enemies.Actions.Common;
using UnityEngine;

namespace Enemies.Actions.Lists
{
    [CreateAssetMenu(fileName = "BoneGolemActions", menuName = "ScriptableObjects/BoneGolemActions", order = 3)]
    public class BoneGolem : ActionSet
    {
        readonly BasicAttack _basicAttack = new BasicAttack(10);        
        readonly BasicVulnerability _basicVulnerability = new BasicVulnerability(3, 0.5f);
        
        
        private void OnEnable() // Use OnEnable for ScriptableObjects instead of Awake
        {
            if(ActionList == null)
                ActionList = new List<IEnemyAction>();
            
            ActionList.Clear(); // Clear before adding to ensure no duplicate actions
            _basicAttack.Initialize();
            _basicVulnerability.Initialize();
            ActionList.Add(_basicAttack);
            ActionList.Add(_basicVulnerability);
        }
    }
}