using Behaviours;
using UnityEngine;

namespace Enemies.Actions
{
    public enum ActionTarget
    {
        Player,
        Self,
        Friendly,
        Group
    }
    
    public interface IEnemyAction
    {
        void Execute(EnemyActor actor);
        ActionTarget Target { get; }
        Sprite ActionIcon { get; }
        
        int Damage { get; }
    }
}