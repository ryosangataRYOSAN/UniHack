using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SEは魔王魂から借りました
// https://maoudamashii.jokersounds.com/core.cgi?page=1&field=%E5%8A%B9%E6%9E%9C%E9%9F%B3%E7%B4%A0%E6%9D%90%3C%3E%E6%88%A6%E9%97%98
public static class SEType{
	public static readonly string Click = "click";
	public static readonly string Attack1 = "attack1";
	public static readonly string Attack2 = "attack2";
}


[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

	protected static AudioPlayer instance;
	public static AudioPlayer Instance{
		get{ 
			if (instance == null) {
				GameObject o = new GameObject ("AudioPlayer");
				DontDestroyOnLoad (o);
				instance = o.AddComponent<AudioPlayer> ();
			}
			return instance;
		}
	}

	List<AudioSource> audioSources = new List<AudioSource>();

	void Awake(){
		audioSources.Add (this.GetComponent<AudioSource> ());
	}


	public void OnDisable(){
		if (instance)
			Destroy (instance.gameObject);
	}

	public static void PlaySE(string seName){
		var ac = Resources.Load<AudioClip> (seName);
		var audioSource = Instance.audioSources.Find (x => !x.isPlaying);
		if (audioSource == null) {
			audioSource = Instance.gameObject.AddComponent<AudioSource> ();
			Instance.audioSources.Add (audioSource);
		}
		audioSource.clip = ac;
		audioSource.Play ();
	}
}
