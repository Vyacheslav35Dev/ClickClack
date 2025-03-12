using Components;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Client
{
    public class TickSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private SceneContext _sceneContext;
        private float _nextActionTime;
        private float _period = 4.0f;
        
        public void Run()
        {
            if (_sceneContext.WorldState == WorldState.Play)
            {
                if (Time.time > _nextActionTime) 
                {
                    _nextActionTime += _period;
                    _world.NewEntity().Get<TickSpawnEvent>();
                }
            }
        }
    }
}