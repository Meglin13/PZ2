﻿using System;
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

            foreach (var saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.GetObjects();
            }

            return state;
        }

        public void RestoreState(object state)
        {
            var stateDictionary = (Dictionary<string, object>)state;

            foreach (var saveable in GetComponents<ISaveable>())
            {
                string typeName = saveable.GetType().ToString();

                if (stateDictionary.TryGetValue(typeName, out object value))
                {
                    saveable.LoadObjects(value);
                }
            }
        }
    }
}
