using Components;
using Components.Tags;
using Leopotam.Ecs;
using RuntimeComponents;
using Services;
using UnityEngine;

namespace Systems
{
    public class GenerateBlockSystem : IEcsRunSystem
    {
        private EcsFilter<TickSpawnEvent> _filter;
        
        private EcsWorld _world;
        private SceneContext _sceneContext;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                entity.Del<TickSpawnEvent>();
                var data = _filter.Get1(i);
                var obj = Object.Instantiate(_sceneContext.Block, _sceneContext.SpawnerBlocks.transform);
                obj.transform.position = new Vector3(_sceneContext.SpawnerBlocks.transform.position.x, Random.Range(-1.5f, 1.5f), 0);
                
                var entityBlock = _world.NewEntity();
                obj.GetComponent<Block>().Init(entityBlock);
                entityBlock.Get<BlockTag>().Object = obj;
                
                entityBlock.Get<MoveComponent>().Object = obj;
                entityBlock.Get<MoveComponent>().To = new Vector3(_sceneContext.DestroerBlocks.transform.position.x, obj.transform.position.y, 0);
                entityBlock.Get<MoveComponent>().Speed = _sceneContext.SpeedBlock;

                entityBlock.Get<RotateComponent>().Object = obj;
                entityBlock.Get<RotateComponent>().Speed = _sceneContext.VelocityBlock;
            }
        }
    }
}