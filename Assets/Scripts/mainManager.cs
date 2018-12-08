using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManager : MonoBehaviour {
	private bool _startTrigger = false;
	public GameObject startUI;
	public GameObject bloom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_startTrigger == false && Input.GetKey(KeyCode.Space)){
			_startTrigger = true;
			startUI.SetActive(false);
			bloom.SetActive(true);
		}
	}
}
