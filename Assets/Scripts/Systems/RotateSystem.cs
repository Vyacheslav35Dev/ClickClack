using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class RotateSystem : IEcsRunSystem
    {
        private EcsFilter<RotateComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var data = ref _filter.Get1(i);
                data.Object.transform.rotation *= Quaternion.Euler(0f,0f,data.Speed);
            }
        }
    }
}