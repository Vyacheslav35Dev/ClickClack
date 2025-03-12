using Client.Components.Tags;
using Components.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class DestroySystem : IEcsRunSystem
    {
        private EcsFilter<DestroyTag> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                entity.Del<DestroyTag>();
                Object.Destroy(data.Object);
                entity.Destroy();
            }
        }
    }
}