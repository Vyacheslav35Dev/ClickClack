using Client.Components.Tags;
using Components.Tags;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace UnityComponents
{
    public class BlockTagWrapper : MonoBehaviour
    {
        private EcsEntity entity;
        
        void Start()
        {
            entity = Service<EcsWorld>.Get().NewEntity();
            entity.Get<BlockTag>().Object = gameObject;
        }
        
        private void OnDestroy()
        {
            entity.Del<BlockTag>();
        }
    }
}