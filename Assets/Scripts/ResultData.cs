using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultData
{

    public int PlayerID { get; private set; }
    public float Score { get; private set; }
    public int Rank { get; private set; }

    public ResultData(int playerId, float score, int rank)
    {
        PlayerID = playerId;
        Score = score;
        Rank = rank;
    }
}
