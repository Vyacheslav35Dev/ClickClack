using Client.Components.Tags;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, MoveComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var data = ref _filter.Get2(i);
                data.Object.transform.position = Vector3.MoveTowards(data.Object.transform.position, data.To, data.Speed * Time.deltaTime);
            }
        }
    }
}