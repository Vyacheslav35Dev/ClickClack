using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace RuntimeComponents
{
    public class Block : MonoBehaviour
    {
        private EcsEntity _entity;
        
        public void Init(EcsEntity entity)
        {
            _entity = entity;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _entity.Get<FinishWorldEvent>();
            }
        }
    }
}