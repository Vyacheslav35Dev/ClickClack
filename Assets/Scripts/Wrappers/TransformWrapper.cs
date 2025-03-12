using System;
using Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace UnityComponents
{
    public class TransformWrapper : MonoBehaviour
    {
        private EcsEntity entity;
        void Start()
        {
            entity = Service<EcsWorld>.Get().NewEntity();
            entity.Get<TransformAbility>().Transform = transform;
        }

        private void OnDestroy()
        {
            entity.Del<TransformAbility>();
        }
    }
}