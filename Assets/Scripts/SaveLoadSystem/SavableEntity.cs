using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    public class SavableEntity : MonoBehaviour
    {
        [SerializeField]
        private string id;
        public string ID => id;

        [ContextMenu("Generate ID")]
        public void GenerateID() => id = Guid.NewGuid().ToString();

        public object CaptureState()
        {
            var state = new Dictionary<string, object>();

            foreach (var saveab1e in GetComponents<ISaveable>())
            {
                state[saveab1e.GetType().ToString()]
                = saveab1e.GetObjects();
            }

            return state;
        }

        public void RestoreState(object state)
        {
            var stateDictionary = (Dictionary<string, object>)state;

            foreach (var saveab1e in GetComponents<ISaveable>())
            {
                string typeName = saveab1e.GetType().ToString();

                if (stateDictionary.TryGetValue(typeName, out object value))
                {
                    saveab1e.LoadObjects(value);
                }
            }
        }
    }
}
