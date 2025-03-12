using Client.Components.Tags;
using Components;
using Components.Tags;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Services;
using Ui;
using UnityEngine;

namespace Systems
{
    public class FinishWorldSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<FinishWorldEvent> _filter;
        
        private EcsFilter<PlayerTag> _filter1;
        private EcsFilter<GoalUpTag> _filter2;
        private EcsFilter<GoalDownTag> _filter3;
        private EcsFilter<BlockTag> _filter4;
        
        private SceneContext _sceneContext;
        private UiManager _uiManager;
        private PlayerService _playerService;
        
        public void Init()
        {
            _sceneContext = Service<SceneContext>.Get();
            _uiManager = Service<UiManager>.Get();
            _playerService = Service<PlayerService>.Get();
        }
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                _uiManager.ShowScreen(ScreenType.WonScreen);
                _sceneContext.WorldState = WorldState.Won;
                
                _playerService.SaveScore();
                
                _sceneContext.Root.SetActive(false);
                
                foreach (var i in _filter1)
                {
                    var e = _filter1.GetEntity(i);
                    var de = _filter1.Get1(i);
                    e.Get<DestroyTag>().Object = de.Object;
                }
                
                foreach (var i in _filter2)
                {
                    var e = _filter2.GetEntity(i);
                    var de = _filter2.Get1(i);
                    e.Get<DestroyTag>().Object = de.Object;
                }
                
                foreach (var i in _filter3)
                {
                    var e = _filter3.GetEntity(i);
                    var de = _filter3.Get1(i);
                    e.Get<DestroyTag>().Object = de.Object;
                }
                
                foreach (var i in _filter4)
                {
                    var e = _filter4.GetEntity(i);
                    var de = _filter4.Get1(i);
                    e.Get<DestroyTag>().Object = de.Object;
                }
                entity.Del<FinishWorldEvent>();
            }
        }
    }
}