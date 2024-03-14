using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies.Actions
{
    [System.Serializable]
    
    public class EnemyAction
    {
        public string Name { get; set; }

        public int Damage { get; set; }
        
        public Sprite ActionIcon { get; set; }        
        
    }
}