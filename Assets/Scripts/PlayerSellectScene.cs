using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSellectScene : MonoBehaviour {

	public void Play1(){
		//mainへ
		AudioPlayer.PlaySE(SEType.Attack1);
		GameUtility.GoGameScene(1);
	}

	public void Play2(){
		//main２へ
		AudioPlayer.PlaySE(SEType.Attack1);
		GameUtility.GoGameScene(2);
	}

	public void Play3(){
		//main３へ
		AudioPlayer.PlaySE(SEType.Attack1);
		GameUtility.GoGameScene(3);
	}

	public void Play4(){
		//main４へ
		AudioPlayer.PlaySE(SEType.Attack1);
		GameUtility.GoGameScene(4);
	}	
}
