using System.Collections.Generic;
using Components;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public enum ScreenType
    {
        StartScreen,
        GameScreen,
        WonScreen
    }
    public class UiManager : MonoBehaviour
    {
        [Header("Screens")]
        [SerializeField]
        private Screen startScreen;
        [SerializeField]
        private Screen gameScreen;
        [SerializeField]
        private Screen wonScreen;
        
        [Header("Buttons")]
        [SerializeField]
        private Button btnStart;
        [SerializeField]
        private Button btnArea;
        [SerializeField]
        private Button btnFinish;
        
        [Header("Score Text")]
        [SerializeField]
        private TMP_Text counterText;
        
        private Dictionary<ScreenType, Screen> _dictScreens = new Dictionary<ScreenType, Screen>();
        private EcsWorld _world;

        public void Init(EcsWorld world)
        {
            _world = world;
            _dictScreens.Add(startScreen.Type, startScreen);
            _dictScreens.Add(gameScreen.Type, gameScreen);
            _dictScreens.Add(wonScreen.Type, wonScreen);
        }

        public void SetScore(string score)
        {
            counterText.text = score;
        }

        public void ShowScreen(ScreenType screen)
        {
            foreach (var screenObj in _dictScreens)
            {
                screenObj.Value.Show(false);
            }
            _dictScreens[screen].Show(true);
        }

        private void ClickBtnStart()
        {
            var entity = _world.NewEntity();
            entity.Get<StartWorldEvent>();
        }
        
        private void ClickAreaBtn()
        {
            var entity = _world.NewEntity();
            entity.Get<AreaClickWorldEvent>();
        }
        
        private void ClickFinishBtn()
        {
            var entity = _world.NewEntity();
            entity.Get<StartWorldEvent>();
        }

        private void OnEnable()
        {
            btnStart.onClick.AddListener(ClickBtnStart);
            btnArea.onClick.AddListener(ClickAreaBtn);
            btnFinish.onClick.AddListener(ClickFinishBtn);
        }
        
        private void OnDisable()
        {
            btnStart.onClick.RemoveListener(ClickBtnStart);
            btnArea.onClick.RemoveListener(ClickAreaBtn);
            btnFinish.onClick.RemoveListener(ClickFinishBtn);
        }
    }
}