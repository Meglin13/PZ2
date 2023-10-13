using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveLoadSystem
{
    public class SaveLoadScript : MonoBehaviour
    {
        public static string SavePath => $"{Application.persistentDataPath}\\GameData.dat";

        private void OnEnable()
        {
            Load();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void Save()
        {
            var state = LoadFile();
            CaptureState(state);
            SaveFile(state);
        }

        private void Load()
        {
            var state = LoadFile();
            RestoreState(state);
        }

        private void SaveFile(Dictionary<string, object> state)
        {
            using (var stream = File.Open(SavePath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        private Dictionary<string, object> LoadFile()
        {
            if (!File.Exists(SavePath))
            {
                return new Dictionary<string, object>();
            }

            using(FileStream stream = File.Open(SavePath, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }
        }

        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<SavableEntity>())
            {
                state[saveable.ID]
                = saveable.CaptureState();
            }
        }

        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (var saveab1e in FindObjectsOfType<SavableEntity>())
            {
                if (state.TryGetValue(saveab1e.ID,out object value))
                {
                    saveab1e.RestoreState(value);
                }
            }
        }
    }
}