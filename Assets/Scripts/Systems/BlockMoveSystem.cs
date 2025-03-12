using Components;
using Components.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class BlockMoveSystem : IEcsRunSystem
    {
        private EcsFilter<BlockTag, MoveComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                ref var data = ref _filter.Get2(i);
                Vector3 pos = data.Object.transform.position;
                if (pos == data.To)
                {
                    entity.Del<MoveComponent>();
                    entity.Get<DestroyTag>();
                    return;
                }
                data.Object.transform.position = Vector3.MoveTowards(data.Object.transform.position, data.To, data.Speed * Time.deltaTime);
                
            }
        }
    }
}