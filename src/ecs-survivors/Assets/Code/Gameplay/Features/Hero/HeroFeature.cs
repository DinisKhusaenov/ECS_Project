using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Features.Hero.Systems;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext, ICameraProvider cameraProvider)
        {
            Add(new SetHeroDirectionByInput(gameContext));
            Add(new AnimateHeroMovementSystem(gameContext));
            Add(new CameraFollowHeroSystem(gameContext, cameraProvider));
        }
    }
}