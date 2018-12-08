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

    [SerializeField]
    ResultRankListView resultRankListView;

    bool flag;

    private void Awake()
    {
        SceneLoader.CurrentOptions = new Options(ResultData.CreateTestModels());
    }

    // Use this for initialization
    void Start()
    {

        options = SceneLoader.CurrentOptions as Options;
        if (options == null)
        {
            Debug.LogError("Score result is null");
        }
        flag = true;
        Debug.Log(options.Results.Count);

        resultDatas = options.Results.OrderBy(value => value.Rank).ToList(); ;

        resultRankListView.SetResultRankItem(resultDatas);

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