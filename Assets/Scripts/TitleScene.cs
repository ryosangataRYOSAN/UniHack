using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{

    bool flag;

    // Use this for initialization
    void Awake()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return) && flag)
        {
            SceneLoader.LoadSceneAsync("Main");
            flag = false;
        }
    }




}
