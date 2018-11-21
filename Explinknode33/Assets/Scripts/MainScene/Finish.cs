using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    #region Variables
    #region Public
    public Image foregroundImg;
    public GameObject finishObj;
    #endregion Public

    #region Private

    #endregion Private
    #endregion Variables

    #region Methods
    #region Public
    public void experimentFinish()
    {
        foregroundImg.enabled = true;
        finishObj.SetActive(true);
    }

    public void closeExperimentFinish()
    {
        foregroundImg.enabled = false;
        finishObj.SetActive(false);
    }

    public void returnButtonFinish()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    public void resetButtonFinish()
    {
        SceneManager.LoadScene("MainScene");
    }
    #endregion Public

    #region Private
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    #endregion Private
    #endregion Methods
}
