using Client.Components.Tags;
using Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Client.RuntimeComponents
{
    public class Player : MonoBehaviour
    {
        private EcsEntity entity;
        
        void Start()
        {
            entity = Service<EcsWorld>.Get().NewEntity();
            entity.Get<PlayerTag>().Object = gameObject;
            entity.Get<RotateComponent>().Speed = 0.9f;
        }
        
        private void OnDestroy()
        {
            entity.Del<PlayerTag>();
        }
    }
}