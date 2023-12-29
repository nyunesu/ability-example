using Installers;
using UnityEngine;

public class GameInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Create()
    {
        GameInstaller gameInstaller = new GameObject("GameInstaller").AddComponent<GameInstaller>();
        Object.DontDestroyOnLoad(gameInstaller.gameObject);
    }
}