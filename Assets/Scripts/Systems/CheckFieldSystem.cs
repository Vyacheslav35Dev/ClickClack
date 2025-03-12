using Client.Components.Tags;
using Components;
using Components.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class CheckFieldSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CollisionGoalEvent> _filter;
        private EcsFilter<GoalUpTag> _filter1;
        private EcsFilter<GoalDownTag> _filter2;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                ref var dataGoalUp = ref _filter1.Get1(0);
                ref var dataGoalDown = ref _filter2.Get1(0);
                if (data.idx == 1)
                {
                    dataGoalUp.Object.SetActive(false);
                    dataGoalDown.Object.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), dataGoalDown.Object.transform.position.y, 0);
                    dataGoalDown.Object.SetActive(true);
                }
                else
                {
                    dataGoalUp.Object.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), dataGoalUp.Object.transform.position.y, 0); 
                    dataGoalUp.Object.SetActive(true);
                    dataGoalDown.Object.SetActive(false);
                }

                _world.NewEntity().Get<CounterEvent>();
                entity.Del<CollisionGoalEvent>();
            }
        }
    }
}