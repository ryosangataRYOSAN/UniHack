using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultRankListView : MonoBehaviour
{


    [SerializeField]
    ResultRankItem[] resultRankItems;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetResultRankItem(List<ResultData> results)
    {

        for (int i = 0; i < resultRankItems.Length; i++)
        {
            if (results.Count > i)
            {
                resultRankItems[i].gameObject.SetActive(true);
                resultRankItems[i].UpdateRankText(results[i]);
            }
            else
            {
                resultRankItems[i].gameObject.SetActive(false);
            }

        }

    }

}
