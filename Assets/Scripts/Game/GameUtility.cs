using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtility {
	public static void GoGameScene (int playerCount) {
		string sceneName = "main" + playerCount.ToString ();
		SceneLoader.LoadSceneAsync (sceneName);
	}

	public static void GoResultScene (List<ResultData> results) {
		SceneLoader.LoadSceneAsync ("Result", new ResultScene.Options (results));
	}
}