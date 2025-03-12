using Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace UnityComponents
{
    public class RotateWrapper : MonoBehaviour
    {
        public float Speed;
        
        private EcsEntity entity;
                
        void Start()
        {
            entity = Service<EcsWorld>.Get().NewEntity();
            entity.Get<RotateComponent>().Speed = Speed;
            entity.Get<RotateComponent>().Object = gameObject;
        }
        
        private void OnDestroy()
        {
            entity.Del<RotateComponent>();
        }
    }
}