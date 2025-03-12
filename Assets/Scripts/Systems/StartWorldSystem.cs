using Client.Components.Tags;
using Client.Utils;
using Components;
using Components.Tags;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using Services;
using Ui;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class StartWorldSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter<StartWorldEvent> _filter;
        private SceneContext _sceneContext;
        private UiManager _uiManager;
        
        public void Init()
        {
            _sceneContext = Service<SceneContext>.Get();
            _uiManager = Service<UiManager>.Get();
        }
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                _uiManager.ShowScreen(ScreenType.GameScreen);
                _sceneContext.WorldState = WorldState.Play;
                
                _uiManager.SetScore("0");
                
                var objPlayer = Object.Instantiate(_sceneContext.Player, _sceneContext.Root.transform);
                var entityPlayer = _world.NewEntity();
                entityPlayer.Get<PlayerTag>().Object = objPlayer;
                entityPlayer.Get<RotateComponent>().Object = objPlayer;
                entityPlayer.Get<RotateComponent>().Speed = _sceneContext.SpeedRotatePlayer;
                
                var objGoalUp = Object.Instantiate(_sceneContext.GoalUp, _sceneContext.Root.transform);
                var entityGoalUp = _world.NewEntity();
                entityGoalUp.Get<GoalUpTag>().Object = objGoalUp;
                entityGoalUp.Get<RotateComponent>().Object = objGoalUp;
                entityGoalUp.Get<RotateComponent>().Speed = _sceneContext.SpeedRotateGoal;
                objGoalUp.GetComponent<Goal>().Init(entityGoalUp, TargetType.Up);
                
                entityPlayer.Get<MoveComponent>().Object = objPlayer;
                entityPlayer.Get<MoveComponent>().To = objGoalUp.transform.position;
                entityPlayer.Get<MoveComponent>().Speed = _sceneContext.SpeedMovePlayer;
                
                var objGoalDown = Object.Instantiate(_sceneContext.GoalDown, _sceneContext.Root.transform);
                var entityGoalDown = _world.NewEntity();
                entityGoalDown.Get<GoalDownTag>().Object = objGoalDown;
                entityGoalDown.Get<RotateComponent>().Object = objGoalDown;
                entityGoalDown.Get<RotateComponent>().Speed = _sceneContext.SpeedRotateGoal;
                objGoalDown.GetComponent<Goal>().Init(entityGoalDown, TargetType.Down);

                Service<SceneContext>.Get().Check = false;
                objGoalDown.SetActive(false);
                
                _sceneContext.Root.SetActive(true);
                entity.Del<StartWorldEvent>();
            }    
        }
    }
}