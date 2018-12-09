using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainManager : MonoBehaviour
{
    public bool startTrigger = false;
    public Text timeLabel;
    public float time = 0f;
    public GameObject bloom;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!startTrigger && Input.GetKey(KeyCode.Space))
        {
            startTrigger = true;
            bloom.SetActive(true);
        }
        if (!startTrigger && Input.GetKey(KeyCode.R))
        {
            string temp = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(temp);   //落ちる　ゆうあい
        }

        if (startTrigger)
        {
            time += Time.deltaTime;
            if (time > 67)
            {
                //ResultSceneへ
				
            }
            else if (time > 60)
            {
                FinishGame();
            }
            else
            {
                timeLabel.text = (60 - time).ToString("f1");
            }
        }

    }

    public void FinishGame()
    {
        timeLabel.text = "おしまい！";
    }
}
