using Leopotam.Ecs;
using UnityEngine;

namespace Components
{
    public class Ability : MonoBehaviour
    {
        public virtual void Convert(EcsEntity entity){}
    }
}