using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRankItem : MonoBehaviour
{

    [SerializeField]
    Text text;

    private void Reset()
    {
        text = this.GetComponentInChildren<Text>(true);
    }

    public void UpdateRankText(ResultData resultData)
    {
        text.text = resultData.Rank.ToString() + "位 : Player " + resultData.PlayerID.ToString() + " Score : " + resultData.Score.ToString();
    }
}
