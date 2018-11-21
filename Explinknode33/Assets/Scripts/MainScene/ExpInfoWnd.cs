using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class ExpInfoWnd : MonoBehaviour
{
    #region Variables
    #region Public
    public GameObject expinfownd;
    public Image foreGround;
    #endregion Public

    #region Private

    #endregion Private
    #endregion Variables

    #region Methods
    #region Public
    public void closeExpInfoWnd()
    {
        expinfownd.SetActive(false);
        foreGround.enabled = false;
    }

    public void openExpInfoWnd()
    {
        expinfownd.SetActive(true);
        foreGround.enabled = true;
    }
    #endregion Public

    #region Private
    // Use this for initialization
    void Start()
    {
        openExpInfoWnd();
    }

    // Update is called once per frame
    void Update()
    {
    }
    #endregion Private
    #endregion Methods
}