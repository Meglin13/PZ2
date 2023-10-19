using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveLoadSystem
{
    public class SaveLoadScript : MonoBehaviour
    {
        public static string SavePath => $"{Application.persistentDataPath}\\GameData.dat";

        [ContextMenu("Delete Save")]
        private void DeleteSave()
        {
            if (File.Exists(SavePath))
            {
                File.Delete(SavePath);
            }
        }

        private void OnEnable() => Load();

        private void OnDisable() => Save();

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
            foreach (var saveable in FindObjectsOfType<SavableEntity>(true))
            {
                state[saveable.ID] = saveable.CaptureState();
            }
        }

        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<SavableEntity>(true))
            {
                if (state.TryGetValue(saveable.ID,out object value))
                {
                    saveable.RestoreState(value);
                }
            }
        }
    }
}