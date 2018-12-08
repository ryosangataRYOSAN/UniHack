using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    public List<GameObject> player = new List<GameObject>();
    private List<Joycon> m_joycons;
    private Joycon m_joycon1;
    private Joycon m_joycon2;
    private Joycon.Button? m_pressedButtonL; //null 許容型
    private Joycon.Button? m_pressedButtonR;

    public GameObject bloom;

    private void Start()
    {
        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joycon1 = m_joycons.Find(c => c.isLeft);
        m_joycon2 = m_joycons.Find(c => !c.isLeft);
    }

    private void Update()
    {

        for (int i = 0; i < m_joycons.Count; i++)
        {
            Quaternion temp = new Quaternion (m_joycons[i].GetVector().x, -m_joycons[i].GetVector().z, m_joycons[i].GetVector().y, m_joycons[i].GetVector().w);
            player[i].transform.rotation = temp;
            player[i].transform.position +=  new Vector3(m_joycons[i].GetStick()[0]/2, m_joycons[i].GetStick()[1]/2, 0);
        }
        m_pressedButtonL = null;
        m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0) return;

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
        //if(Vector3.Dot(bloom.transform.position,new Vector3(bloom.transform.position.x, bloom.transform.position.y, transform.position.z) <= 0.5f);
        if(Mathf.Abs(90 - bloom.transform.eulerAngles.x) >= 10 | Mathf.Abs(90 - bloom.transform.eulerAngles.z) >= 10) //| bloom.transform.rotation.z)
        {
            Destroy(bloom.GetComponent<HingeJoint>());
            Debug.Log("gameOver");
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

        GUILayout.EndHorizontal();
    }
}