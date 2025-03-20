using System;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private ITimeService _timeService;
        
        private BattleFeature _battleFeature;

        [Inject]
        private void Constructor(GameContext gameContext, ITimeService timeService)
        {
            _gameContext = gameContext;
            _timeService = timeService;
        }

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _timeService);
            _battleFeature.Initialize();
        }

        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}