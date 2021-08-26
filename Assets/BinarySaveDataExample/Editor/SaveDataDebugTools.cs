using UnityEditor;
using UnityEngine;

public class SaveDataDebugTools
{
    [MenuItem("Tools/Save Game (Binary)")]
    static void SaveBinaryGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            var entities = GameObject.FindObjectsOfType<Entity>();
            saveManager.SaveData.SetEntities(entities);
            saveManager.SaveBinary("savedata01.dat", saveManager.SaveData);
        }
    }

    [MenuItem("Tools/Load Game (Binary)")]
    static void LoadBinaryGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            var entities = GameObject.FindObjectsOfType<Entity>();
            foreach (var entity in entities)
            {
                GameObject.Destroy(entity.gameObject);
            }

            saveManager.LoadBinary("savedata01.dat", saveManager.SaveData);
        }
    }

    [MenuItem("Tools/Save Game (JSON)")]
    static void SaveJsonGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            saveManager.SaveData.SetEntities(GameObject.FindObjectsOfType<Entity>());
            saveManager.SaveJson("savedata01.json", saveManager.SaveData);
        }
    }

    [MenuItem("Tools/Load Game (JSON)")]
    static void LoadJsonGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            var entities = GameObject.FindObjectsOfType<Entity>();
            foreach (var entity in entities)
            {
                GameObject.Destroy(entity.gameObject);
            }

            saveManager.LoadJson("savedata01.json", saveManager.SaveData);
        }
    }
}