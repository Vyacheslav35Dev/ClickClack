using Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Services;
using Ui;

namespace Systems
{
    public class CounterSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<CounterEvent> _filter;
        
        private PlayerService _playerService;
        private UiManager _uiManager;
        
        public void Init()
        {
            _playerService = Service<PlayerService>.Get();
            _uiManager = Service<UiManager>.Get();
        }
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                
                var scoreCurrent = _playerService.GetScore() + 1;
                _playerService.SetScore(scoreCurrent);
                _uiManager.SetScore(scoreCurrent.ToString());
                
                entity.Del<CounterEvent>();
            } 
        }
    }
}