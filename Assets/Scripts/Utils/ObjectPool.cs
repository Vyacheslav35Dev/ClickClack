using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    public static class ObjectPool
    {
        public static Dictionary<GameObject, List<GameObject>> Cached = new Dictionary<GameObject, List<GameObject>>();

        public static GameObject SpawnCached(this GameObject prefab, Vector3 position = default,
            Quaternion rotation = default)
        {
            if (!prefab)
            {
                Debug.Log("No Prefab");
                return default;
            }

            if (!Cached.TryGetValue(prefab, out var list))
            {
                list = new List<GameObject>();
                Cached[prefab] = list;
            }

            if (list.Any())
            {
                var first = list[0];
                list.RemoveAt(0);
                first.SetActive(true);
                first.transform.position = position;
                first.transform.rotation = rotation;
                return first;
            }

            var go = Object.Instantiate(prefab, position, rotation);
            var cached = go.AddComponent<CashOnDisable>();
            cached.Cached = list;
            return go;
        }
    }

    public class CashOnDisable : MonoBehaviour
    {
        public List<GameObject> Cached;

        private void OnDisable()
        {
            Cached.Add(gameObject);
        }
    }
}