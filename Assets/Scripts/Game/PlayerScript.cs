﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];
    public List<GameObject> player = new List<GameObject>();
    public List<GameObject> bloom = new List<GameObject>();
    public List<ResultData> resultArray = new List<ResultData>();
    private bool[] finishTrigger = { false, false, false, false };
    public mainManager mm;
    public GameObject ex;
    private List<Joycon> m_joycons;
    private Joycon m_joycon1;
    private Joycon m_joycon2;
    private Joycon.Button? m_pressedButtonL; //null 許容型
    private Joycon.Button? m_pressedButtonR;

    int gameOverCount = 0;


    private void Start()
    {
        mm = this.GetComponent<mainManager>();

        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joycon1 = m_joycons.Find(c => c.isLeft);
        m_joycon2 = m_joycons.Find(c => !c.isLeft);
    }

    private void Update()
    {
        m_pressedButtonL = null;
        m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        //ボタン判定
        foreach (var button in m_buttons)
        {
            if (m_joycon1.GetButton(button))
            {
                m_pressedButtonL = button;
            }
            if (m_joycon2.GetButton(button))
            {
                m_pressedButtonR = button;
            }
        }



        //回転・移動とってるとこ
        for (int i = 0; i < m_joycons.Count; i++)
        {
            if (player[i] == null) continue;

            player[i].transform.rotation = m_joycons[i].GetVector();
            if (mm.startTrigger)
            {
                player[i].transform.position += new Vector3(m_joycons[i].GetStick()[0] / 2, m_joycons[i].GetStick()[1] / 2, 0);
            }
        }

        if (finishTrigger[0])
        {
            if (m_joycons.Count == 1)
            {
                //Resultへ
                mm.FinishGame();
            }
            else if (finishTrigger[1])
            {
                if (m_joycons.Count == 2)
                {
                    //Resultへ
                    mm.FinishGame();
                }
                else if (finishTrigger[2])
                {
                    if (m_joycons.Count == 3)
                    {
                        //Resultへ
                        mm.FinishGame();
                    }
                    else if (finishTrigger[3])
                    {
                        //Resultへ
                        mm.FinishGame();
                    }

                }
            }
        }


        for (int i = 0; i < bloom.Count; i++)
        {
            if (bloom[i] == null) continue;

            Debug.Log(Mathf.Abs(90 - bloom[i].transform.localEulerAngles.x));
            //if (Vector3.Dot(bloom[i].transform.position, player[i].transform.position) <= 110f)
            if (Mathf.Abs(90 - bloom[i].transform.localEulerAngles.x) <= 60)
            {
                Destroy(bloom[i].GetComponent<HingeJoint>());
            }

            if (bloom[i].transform.position.z > 30)
            {
                Instantiate(ex, bloom[i].transform.position, bloom[i].transform.rotation);
                //m_joycons[i].SetRumble(160, 320, 0.6f, 50);
                int rank = player.Count - gameOverCount;
                gameOverCount++;
                var resultData = new ResultData(i+1, mm.time, rank);
                resultArray.Add(resultData);
                Destroy(bloom[i]);
                Destroy(player[i]);
                finishTrigger[i] = true;
            }
        }

        //バイブレーション
        // if ( Input.GetKeyDown( KeyCode.Z ) )
        // {
        //     m_joycon1.SetRumble( 160, 320, 0.6f, 200 );
        // }
        // if ( Input.GetKeyDown( KeyCode.X ) )
        // {
        //     m_joycon2.SetRumble( 160, 320, 0.6f, 200 );
        // }

    }

    public void Score()
    {
        for (int i = player.Count; i >= 0; i--)
        {
            if(player[i-1] != null){
                var resultData = new ResultData(i, 60, 1);
                resultArray.Add(resultData);
            }
        }
    }

    private void OnGUI()
    {
        var style = GUI.skin.GetStyle("label");
        style.fontSize = 24;

        if (m_joycons == null || m_joycons.Count <= 0)
        {
            GUILayout.Label("Joy-Con が接続されていません");
            return;
        }

        if (!m_joycons.Any(c => c.isLeft))
        {
            GUILayout.Label("Joy-Con (L) が接続されていません");
            return;
        }

        if (!m_joycons.Any(c => !c.isLeft))
        {
            GUILayout.Label("Joy-Con (R) が接続されていません");
            return;
        }

        GUILayout.BeginHorizontal(GUILayout.Width(960));

        // foreach (var joycon in m_joycons)
        // {
        //     var isLeft = joycon.isLeft;
        //     var name = isLeft ? "Joy-Con (L)" : "Joy-Con (R)";
        //     var key = isLeft ? "Z キー" : "X キー";
        //     var button = isLeft ? m_pressedButtonL : m_pressedButtonR;
        //     var stick = joycon.GetStick();
        //     var gyro = joycon.GetGyro();
        //     var accel = joycon.GetAccel();
        //     var orientation = joycon.GetVector();

        //     GUILayout.BeginVertical(GUILayout.Width(480));
        //     GUILayout.Label(name);
        //     GUILayout.Label(key + "：振動");
        //     GUILayout.Label("押されているボタン：" + button);
        //     GUILayout.Label(string.Format("スティック：({0}, {1})", stick[0], stick[1]));
        //     GUILayout.Label("ジャイロ：" + gyro);
        //     GUILayout.Label("加速度：" + accel);
        //     GUILayout.Label("傾き：" + orientation);
        //     GUILayout.EndVertical();
        // }

        // GUILayout.EndHorizontal();
    }
}