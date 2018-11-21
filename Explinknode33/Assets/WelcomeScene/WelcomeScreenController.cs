using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WelcomeScreenController : MonoBehaviour
{
    #region Variables
    #region Public
    public Button ContentButton;
    public Button PurposeButton;

    public Sprite ContentButtonActivated;
    public Sprite ContentButtonDisabled;
    public Sprite PurposeButtonActivated;
    public Sprite PurposeButtonDisabled;
    public GameObject Content;
    public GameObject Purpose;
    #endregion Public

    #region Private

    #endregion Private
    #endregion Variables

    #region Methods
    #region Public
    public void OnPurposeButtonClick()
    {
        ContentButton.image.sprite = ContentButtonDisabled;
        PurposeButton.image.sprite = PurposeButtonActivated;
        Content.SetActive(false);
        Purpose.SetActive(true);
    }

    public void OnContentButtonClick()
    {
        ContentButton.image.sprite = ContentButtonActivated;
        PurposeButton.image.sprite = PurposeButtonDisabled;
        Content.SetActive(true);
        Purpose.SetActive(false);
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnReturnButtonClick()
    {
        Application.ExternalCall("CloseWindow", "");
    }
    #endregion Public

    #region Private
    // Use this for initialization
    void Start()
    {
        ContentButton.image.sprite = ContentButtonDisabled;
        PurposeButton.image.sprite = PurposeButtonActivated;
        Content.SetActive(false);
        Purpose.SetActive(true);
    }
    #endregion Private
    #endregion Methods
}
