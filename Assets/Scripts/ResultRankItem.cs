using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRankItem : MonoBehaviour
{

    [SerializeField]
    Text player;
    [SerializeField]
    Text score;

    private void Reset()
    {
        player = this.GetComponentInChildren<Text>(true);
        score = this.GetComponentInChildren<Text>(true);
    }

    public void UpdateRankText(ResultData resultData)
    {
        player.text = "プレイヤー " + resultData.PlayerID.ToString();
        score.text = "Score : " + resultData.Score.ToString();
    }
}
