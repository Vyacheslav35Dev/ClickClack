using Systems;
using Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Services;
using Ui;
using UnityEngine;

namespace Client 
{
    sealed class Bootstrap : MonoBehaviour 
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [Header("Scene Configuration")]
        [SerializeField] 
        private SceneContext sceneContext;
        
        [Header("Ui")]
        [SerializeField] 
        private UiManager uiManager;
        
        [Header("PlayerService")]
        [SerializeField] 
        private PlayerService playerService;

        private void Start () 
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            
            uiManager.Init(_world);
            uiManager.SetScore(playerService.GetScoreText());
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            Service<PlayerService>.Set(playerService);
            Service<SceneContext>.Set(sceneContext);
            Service<UiManager>.Set(uiManager);
            Service<EcsWorld>.Set(_world);
            
            _systems
                .Add(new StartWorldSystem()).OneFrame<StartWorldEvent>()
                .Add(new FinishWorldSystem())
                
                .Add(new CheckTargetSystem()).OneFrame<AreaClickWorldEvent>()
                .Add(new CheckFieldSystem()).OneFrame<CollisionGoalEvent>()
                .Add(new TickSystem())
                .Add(new GenerateBlockSystem())
                .Add(new BlockMoveSystem())
                .Add(new DestroyerBlockSystem())
                .Add(new CounterSystem())
                .Add(new PlayerMoveSystem())
                .Add(new RotateSystem())
                .Add(new DestroySystem())
                
                .Inject (uiManager)
                .Inject (sceneContext)
                .Inject (playerService)
                .Init ();
        }

        private void Update () 
        {
            _systems?.Run ();
        }

        private void OnDestroy () 
        {
            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
            Service<SceneContext>.Set(null);
            Service<EcsWorld>.Set(null);
        }
    }
}