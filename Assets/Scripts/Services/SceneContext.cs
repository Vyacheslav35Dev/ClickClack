using UnityEngine;
using UnityEngine.Serialization;

namespace Services
{
    public enum WorldState
    {
        Start,
        Play,
        Won
    }
    [SerializeField]
    public class SceneContext : MonoBehaviour
    {
        [Header("Settings Player")]
        public GameObject Player;
        public float SpeedMovePlayer = 0.5f;
        public float SpeedRotatePlayer = 0.7f;
        
        [Header("Settings Goal")]
        public float SpeedRotateGoal = 0.5f;
        public GameObject GoalUp;
        public GameObject GoalDown;
        
        [Header("Settings Block")]
        public GameObject Block;
        public GameObject SpawnerBlocks;
        public GameObject DestroerBlocks;
        public float SpeedBlock = 0.5f;
        public float VelocityBlock = 0.5f;
        
        public WorldState  WorldState;
        public GameObject Root;
        
        public bool Check = true;
    }
}