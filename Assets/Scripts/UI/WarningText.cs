using UnityEngine;
using UnityEngine.UI;

public class WarningText : MonoBehaviour
{
    private enum alphaValue
    {
        SHRINKING,
        GROWING,
    }

    private alphaValue currentAlphaValue;
    [SerializeField] private float CommentminAlpha;
    [SerializeField] private float CommentmaxAlpha;
    [SerializeField] private float CommentCurrentAlpha;
    [SerializeField] private bool flashText;

    [SerializeField] private Text MyText;

    void Start()
    {
        CommentminAlpha = 0f;
        CommentmaxAlpha = 1.0f;
        CommentCurrentAlpha = 1.0f;
        currentAlphaValue = alphaValue.SHRINKING;
    }

    void Update()
    {
        if (flashText == true)
        {
            alphaComments();
        }
        
    }

    public void SetIsAllowedToFlash(bool textFlash)
    {
        flashText = textFlash;
    }

    private void alphaComments()
    {
        if (currentAlphaValue == alphaValue.SHRINKING)
        {
            CommentCurrentAlpha = CommentCurrentAlpha - 0.005f;
            MyText.color = new Color(Color.white.r, Color.white.g, Color.white.b, CommentCurrentAlpha);
            if (CommentCurrentAlpha <= CommentminAlpha)
            {
                currentAlphaValue = alphaValue.GROWING;
            }
        }
        else if (currentAlphaValue == alphaValue.GROWING)
        {
            CommentCurrentAlpha = CommentCurrentAlpha + 0.005f;
            MyText.color = new Color(Color.white.r, Color.white.g, Color.white.b, CommentCurrentAlpha);
            if (CommentCurrentAlpha >= CommentmaxAlpha)
            {
                currentAlphaValue = alphaValue.SHRINKING;
            }
        }
    }
}
