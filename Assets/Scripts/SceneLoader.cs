using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static object CurrentOptions;


    public static void LoadSceneAsync(string path)
    {
        CoroutineHandler.StartStaticCoroutine(LoadSceneCoroutine(path));
    }


    static IEnumerator LoadSceneCoroutine(string path)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has

        // a sceneBuildIndex of 1 as shown in Build Settings.
        //var cashedTime = Time.time;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(path);
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        //while (Time.time < cashedTime + 5f)
        //{

        //    yield return null;
        //}

        asyncLoad.allowSceneActivation = true;


    }
}
