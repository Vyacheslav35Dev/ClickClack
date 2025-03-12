using Client.Components.Tags;
using Components;
using Components.Tags;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Services;

namespace Systems
{
    public class CheckTargetSystem : IEcsRunSystem
    {
        private EcsFilter<AreaClickWorldEvent> _filter;
        private EcsFilter<PlayerTag, MoveComponent> _filter1;
        private EcsFilter<GoalUpTag> _filter2;
        private EcsFilter<GoalDownTag> _filter3;

        private SceneContext _sceneContext;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var data = ref _filter1.Get2(0);
                var check = Service<SceneContext>.Get().Check;
                if (check)
                {
                    data.To = _filter2.Get1(0).Object.transform.position;
                    Service<SceneContext>.Get().Check = false;
                }
                else
                {
                    data.To = _filter3.Get1(0).Object.transform.position;
                    Service<SceneContext>.Get().Check = true;
                }
                
            }
        }
    }
}