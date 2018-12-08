using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResultScene : MonoBehaviour
{

    public class Options
    {

        public List<ResultData> Results
        {
            get; private set;
        }

        public Options(List<ResultData> results)
        {
            Results = results;
        }
    }

    Options options = null;

    List<ResultData> resultDatas = null;

    bool flag;

    // Use this for initialization
    void Start()
    {

        ResultData c = new ResultData(0, 0f, 3);
        ResultData a = new ResultData(1, 0f, 1);
        ResultData b = new ResultData(0, 0f, 2);
        ResultData d = new ResultData(1, 0f, 5);

        List<ResultData> z = new List<ResultData>
        {
            a,
            b,
            c,
            d
        };


        options = new Options(z);
        //options = SceneLoader.CurrentOptions as Options;

        if (options == null)
        {
            Debug.LogError("Score result is null");

        }
        flag = true;

        resultDatas = options.Results;
        resultDatas = resultDatas.OrderBy(value => value.Rank).ToList();

        foreach (ResultData result in options.Results)
        {
            Debug.Log(result.Rank);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return) && flag)
        {
            SceneLoader.LoadSceneAsync("Title");
            flag = false;
        }
    }
}