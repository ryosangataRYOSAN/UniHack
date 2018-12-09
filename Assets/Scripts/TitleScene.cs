using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Return)) {
            AudioPlayer.PlaySE (SEType.Attack1);
            SceneLoader.LoadSceneAsync ("playerSelect");
        }
    }
}