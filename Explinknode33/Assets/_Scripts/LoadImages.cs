using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadImages : MonoBehaviour
{
    #region Variables
    #region Public
    public Image img;
    public TextAsset bgImageAsset;
    public int width = 1920;
    public int height = 1080;
    #endregion Public

    #region Private
    Vector2 pivot = new Vector2(1.0f, 1.0f);
    #endregion Private
    #endregion Variables

    #region Methods
    #region Public

    #endregion Public

    #region Private
    // Use this for initialization
    void Start ()
    {
        Texture2D texture = new Texture2D(width, height,TextureFormat.ARGB32,false);
        texture.LoadImage(bgImageAsset.bytes);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, width, height), pivot);
        img.sprite = sprite;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
    #endregion Private
    #endregion Methods
}
