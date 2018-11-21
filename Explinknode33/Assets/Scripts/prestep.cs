using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class prestep : MonoBehaviour
{
    public Text T2;
    public Text T3;
    public Text T4;
    public Text T5;

    public GameObject programPanel;
    public GameObject programPanelpre;

    public startprogram2 startprogram2ref_;
    public startprogram3 startprogram3ref_;
    public startprogram4 startprogram4ref_;
    public startprogram5 startprogram5ref_;

    public memorystart startref_;

    public void onClickPre()
    {
        startprogram2ref_.Clickcount = 0;
        startprogram3ref_.Clickcount = 0;
        startprogram4ref_.Clickcount = 0;
        T2.color = Color.black;
        T3.color = Color.black;
        T4.color = Color.black;
        T5.color = Color.black;

        programPanel.SetActive(false);
        programPanelpre.SetActive(true);

        startref_.flagEnd = false;
    }
}
