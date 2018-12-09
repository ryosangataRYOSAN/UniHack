using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static object CurrentOptions;

    // バリア生成が面倒なので作成
    static bool isLoading = false;

    /// <summary>
    /// シーン遷移時にパラメータを渡したい場合はoptionsにいれる
    /// 例) LoadSceneAsync("Result", new ResultScene.Options(results));
    /// </summary>
    public static void LoadSceneAsync(string path, object options = null)
    {
        if(isLoading)
            return;
        CoroutineHandler.StartStaticCoroutine(LoadSceneCoroutine(path, options));
    }
    
    static IEnumerator LoadSceneCoroutine(string path, object options = null)
    {
        CurrentOptions = options;
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has

        // a sceneBuildIndex of 1 as shown in Build Settings.
        //var cashedTime = Time.time;
        isLoading = true;
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
        isLoading = false;
    }
}
