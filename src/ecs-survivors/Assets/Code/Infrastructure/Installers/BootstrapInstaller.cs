using Code.Common.EntityIndices;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Enchants.UIFactories;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.LevelUp.Services;
using Code.Gameplay.Features.LevelUp.Windows;
using Code.Gameplay.Features.Loot.Factory;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Features.Statuses.Factory;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using RSG;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
  {
    public override void InstallBindings()
    {
      BindInputService();
      BindContexts();
      BindInfrastructureServices();
      BindAssetManagementServices();
      BindCommonServices();
      BindSystemFactory();
      BindGameplayServices();
      BindCameraProvider();
      BindStateMachine();
      BindStateFactory();
      BindGameplayFactory();
      BindEntityIndices();
      BindUIFactories();
      BindUIServices();
    }

    private void BindUIFactories()
    {
      Container.Bind<IEnchantUIFactory>().To<EnchantUIFactory>().AsSingle();
      Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
      Container.Bind<IAbilityUIFactory>().To<AbilityUIFactory>().AsSingle();
    }
    
    private void BindUIServices()
    {
      Container.Bind<IWindowService>().To<WindowService>().AsSingle();
    }

    private void BindEntityIndices()
    {
      Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
    }

    private void BindStateMachine()
    {
      Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
    }

    private void BindStateFactory()
    {
      Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
    }
    
    private void BindContexts()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
   
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }

    private void BindCameraProvider()
    {
      Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
    }

    private void BindGameplayServices()
    {
      Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
      Container.Bind<IStatusApplier>().To<StatusApplier>().AsSingle();
      Container.Bind<ILevelUpService>().To<LevelUpService>().AsSingle();
      Container.Bind<IAbilityUpgradeService>().To<AbilityUpgradeService>().AsSingle();
    }

    private void BindGameplayFactory()
    {
      Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
      Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
      Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
      Container.Bind<IArmamentFactory>().To<ArmamentFactory>().AsSingle();
      Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
      Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
      Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
      Container.Bind<ILootFactory>().To<LootFactory>().AsSingle();
    }

    private void BindSystemFactory()
    {
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
    }

    private void BindInfrastructureServices()
    {
      Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
      Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
    }

    private void BindAssetManagementServices()
    {
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }

    private void BindCommonServices()
    {
      Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
      Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
      Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
    }

    private void BindInputService()
    {
      Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
    }
    
    public void Initialize()
    {
      Promise.UnhandledException += LogPromiseException;
    }

    private void LogPromiseException(object sender, ExceptionEventArgs e)
    {
      Debug.LogError(e.Exception);
    }
  }
}