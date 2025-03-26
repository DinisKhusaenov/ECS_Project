using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroAnimatorRegistrar: EntityComponentRegistrar
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        
        public override void RegisterComponents()
        {
            Entity
                .AddDamageTakenAnimator(_heroAnimator)
                .AddHeroAnimator(_heroAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasHeroAnimator)
                Entity.RemoveHeroAnimator();
            
            if (Entity.hasDamageTakenAnimator)
                Entity.RemoveDamageTakenAnimator();
        }
    }
}