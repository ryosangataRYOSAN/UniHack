using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRankItem : MonoBehaviour
{

    Text text;

    private void Awake()
    {
        text = this.gameObject.GetComponent<Text>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateRankText(string inputText)
    {
        text.text = inputText;
    }
}
