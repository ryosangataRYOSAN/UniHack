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

    public static List<ResultData> CreateTestModels()
    {
        return new List<ResultData>
        {
            new ResultData(2, 0f, 3),
            new ResultData(1, 0f, 1),
            new ResultData(3, 0f, 2),
            new ResultData(4, 0f, 5)
        };
    }
}
