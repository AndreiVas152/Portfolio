using Behaviours;
using UnityEngine;

namespace Enemies.Actions.Common
{
    public class BasicAttack : IEnemyAction
    {
        public int Damage { get;}
        public string Name = nameof(BasicAttack);
        public Sprite ActionIcon { get; private set; }
        public ActionTarget Target => ActionTarget.Player;

        public BasicAttack(int damage)
        {
            Damage = damage;            
        }

        public void Initialize()
        {
            ActionIcon = Resources.Load<Sprite>("Attack");
        }

        public void Execute(EnemyActor actor)
        {
            EnemyManager.Instance.DoDamageRequest(Damage, Target, actor);
        }
    }
}
    