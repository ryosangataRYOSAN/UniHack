using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtility  {
	public static void GoGameScene(bool isMaltiPlay){
			if(!isMaltiPlay){
				SceneLoader.LoadSceneAsync("main");
			}else{
				//これから
			}
	}
}
