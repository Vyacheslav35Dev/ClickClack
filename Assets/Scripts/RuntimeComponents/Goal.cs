using Client.Utils;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents
{
    public class Goal : MonoBehaviour
    {
        private EcsEntity _entity;
        private TargetType _type;

        public void Init(EcsEntity entity, TargetType type)
        {
            _entity = entity;
            _type = type;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_type == TargetType.Up)
            {
                _entity.Get<CollisionGoalEvent>().idx = 1;
            }
            else
            {
                _entity.Get<CollisionGoalEvent>().idx = 2;
            }
        }
    }
}