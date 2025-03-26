using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyAnimatorRegistrar: EntityComponentRegistrar
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        
        public override void RegisterComponents()
        {
            Entity
                .AddDamageTakenAnimator(_enemyAnimator)
                .AddEnemyAnimator(_enemyAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnemyAnimator)
                Entity.RemoveEnemyAnimator();
            
            if (Entity.hasDamageTakenAnimator)
                Entity.RemoveDamageTakenAnimator();
        }
    }
}