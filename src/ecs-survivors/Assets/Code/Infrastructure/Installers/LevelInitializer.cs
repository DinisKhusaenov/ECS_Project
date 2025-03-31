using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class LevelInitializer : MonoBehaviour, IInitializable
  {
      public Camera MainCamera;
      public Transform StartPoint;
      private ICameraProvider _cameraProvider;
      private ILevelDataProvider _levelDataProvider;
      private IStaticDataService _staticDataService;

      [Inject]
      private void Construct(
        ICameraProvider cameraProvider,
        ILevelDataProvider levelDataProvider,
        IStaticDataService staticDataService
      )
      {
        _levelDataProvider = levelDataProvider;
        _cameraProvider = cameraProvider;
        _staticDataService = staticDataService;
      }
      
      public void Initialize()
      {
        _levelDataProvider.SetStartPoint(StartPoint.position);
        _cameraProvider.SetMainCamera(MainCamera);
        _staticDataService.LoadAll();
      }
  }
}