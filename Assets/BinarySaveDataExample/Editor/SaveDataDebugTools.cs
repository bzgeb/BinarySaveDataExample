using UnityEditor;
using UnityEngine;

public class SaveDataDebugTools
{
    [MenuItem("Tools/Save Game (Binary)")]
    static void SaveBinaryGame()
    {
        if (Application.isPlaying)
        {
            var game = GameObject.FindObjectOfType<Game>();
            game.SaveGame(false);
        }
    }

    [MenuItem("Tools/Load Game (Binary)")]
    static void LoadBinaryGame()
    {
        if (Application.isPlaying)
        {
            var game = GameObject.FindObjectOfType<Game>();
            game.LoadGame(false);
        }
    }

    [MenuItem("Tools/Save Game (JSON)")]
    static void SaveJsonGame()
    {
        if (Application.isPlaying)
        {
            var game = GameObject.FindObjectOfType<Game>();
            game.SaveGame(true);
        }
    }

    [MenuItem("Tools/Load Game (JSON)")]
    static void LoadJsonGame()
    {
        if (Application.isPlaying)
        {
            var game = GameObject.FindObjectOfType<Game>();
            game.LoadGame(true);
        }
    }
}