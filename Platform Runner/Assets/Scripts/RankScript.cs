using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankScript : MonoBehaviour
{
    [SerializeField] private Transform finishLine;
    public float distance;
    public GameObject[] gOs;
    [SerializeField] private GameObject boy;
    private int boyRank;
    [SerializeField] private TMP_Text tM,tM1;
    [SerializeField] private GameObject Panel;


  
    void Update()
    {
        gOs = GameObject.FindGameObjectsWithTag("human");
        distance = Vector3.Distance(finishLine.position, transform.position);

        for (int i = 0; i < gOs.Length; i++)
        {
            for (int j = 1; j < gOs.Length; j++)
            {
                if (gOs[j - 1].GetComponent<RankScript>().distance > gOs[j].GetComponent<RankScript>().distance)
                {
                    GameObject tmp = gOs[j];
                    gOs[j] = gOs[j - 1];
                    gOs[j - 1] = tmp;
                }
            }

            

        }

        for(int k=0; k<gOs.Length; k++)
        {
            if (boy == gOs[k] && boy.GetComponent<CharacterScript>().isRankOk==false)
            {
                boyRank = k + 1;
                tM.text = "" + boyRank;
                tM1.text = "" + boyRank;
            }
        }

        if (boy.GetComponent<CharacterScript>().isRankOk == true)
        {
            Panel.SetActive(true);
            tM.text = "";
        }
        
    }

}
