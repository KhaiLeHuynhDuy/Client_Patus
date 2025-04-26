using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading;

public static class SceneSwitcher
{
    private static Scene oldScene;

    private static Scene newScene;

    public static bool isNewSceneLoaded = false;

    // DO NOT REMOVE THIS
    static SceneSwitcher()
    {
        oldScene = SceneManager.GetActiveScene();
    }

    public static async System.Threading.Tasks.Task LoadNewSceneAsync(int index)
    {
        if (SceneManager.GetActiveScene().buildIndex == index)
        {
            return;
        }
        if (!isNewSceneLoaded)
        {
            // Load the new scene asynchronously and additively
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                await System.Threading.Tasks.Task.Yield();
            }

            // Set the newScene variable to the loaded scene
            newScene = SceneManager.GetSceneAt(index);
            isNewSceneLoaded = true;
        }
        SwitchToNewScene();
    }

    public static void SwitchToNewScene()
    {
        if (oldScene.IsValid())
        {
            //GameObject[] gameObjects = oldScene.GetRootGameObjects();
            //gameObjects[0].SetActive(false);
            GameScr.isPaint = false;
        }
        if (newScene.IsValid())
        {
            SceneManager.SetActiveScene(newScene);
            // GameObject[] gameObjects = newScene.GetRootGameObjects();
            // gameObjects[0].SetActive(true);
            GameScr2.isPaint = true;
            Debug.Log("Switched to new scene: " + newScene.name);
        }
        else
        {
            Debug.LogWarning("New scene is not valid!");
        }
    }

    public static void SwitchBackToOldScene()
    {
        if (newScene.IsValid())
        {
            // GameObject[] gameObjects = newScene.GetRootGameObjects();
            // gameObjects[0].SetActive(false);
            GameScr2.isPaint = false;
        }
        if (oldScene.IsValid())
        {
            SceneManager.SetActiveScene(oldScene);
            // GameObject[] gameObjects = oldScene.GetRootGameObjects();
            // gameObjects[0].SetActive(true);
            GameScr.isPaint = true;
            Debug.Log("Switched back to old scene: " + oldScene.name);
        }
        else
        {
            Debug.LogWarning("Old scene is not valid!");
        }
    }

    public static void UnloadNewScene()
    {
        if (isNewSceneLoaded && newScene.IsValid())
        {
            GameMidlet2.instance.exit();
            SceneManager.UnloadSceneAsync(newScene);
            newScene = default; // Reset the newScene variable
            isNewSceneLoaded = false;
            Debug.Log("Unloaded new scene");
        }
        else
        {
            Debug.LogWarning("New scene is not loaded or not valid!");
        }
    }

    public static string GetCurrSceneName()
    {
        if (Thread.CurrentThread.Name == Main.mainThreadName)
        {
            return SceneManager.GetActiveScene().name;
        }
        else
        {
            return string.Empty;
        }
    }
}
