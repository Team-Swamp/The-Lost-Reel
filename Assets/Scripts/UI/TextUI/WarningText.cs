using UnityEngine;
using TMPro;

public sealed class WarningText : MonoBehaviour
{
    private enum alphaValue
    {
        SHRINKING,
        GROWING,
    }

    private alphaValue _currentAlphaValue;
    [SerializeField] private float CommentminAlpha;
    [SerializeField] private float CommentmaxAlpha;
    [SerializeField] private float CommentCurrentAlpha;
    [SerializeField] private bool isAllowedToflash;
    [SerializeField, Range(0, 0.01f)] private float flashingSpeed = 0.005f;
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        CommentminAlpha = 0f;
        CommentmaxAlpha = 1.0f;
        CommentCurrentAlpha = 0f;
        _currentAlphaValue = alphaValue.SHRINKING;
    }

    private void Update()
    {
        if (isAllowedToflash)
        {
            alphaComments();
        }
        else
        {
            ShrinkAlpha();
        }
    }
    public void SetIsAllowedToFlash(bool targetValue)
    {
        isAllowedToflash = targetValue;
    }

    private void alphaComments()
    {
        if (_currentAlphaValue == alphaValue.SHRINKING)
        {
            CommentCurrentAlpha -= flashingSpeed;
            text.color = new Color(Color.white.r, Color.white.g, Color.white.b, CommentCurrentAlpha);
            if (CommentCurrentAlpha <= CommentminAlpha)
            {
                _currentAlphaValue = alphaValue.GROWING;
            }
        }
        else if (_currentAlphaValue == alphaValue.GROWING)
        {
            CommentCurrentAlpha += flashingSpeed;
            text.color = new Color(Color.white.r, Color.white.g, Color.white.b, CommentCurrentAlpha);
            if (CommentCurrentAlpha >= CommentmaxAlpha)
            {
                _currentAlphaValue = alphaValue.SHRINKING;
            }
        }
    }
    
    private void ShrinkAlpha()
    {
        if (CommentCurrentAlpha <= 0) return;
        
        CommentCurrentAlpha -= flashingSpeed;
        text.color = new Color(Color.white.r, Color.white.g, Color.white.b, CommentCurrentAlpha);
        if (CommentCurrentAlpha >= CommentmaxAlpha)
        {
            _currentAlphaValue = alphaValue.SHRINKING;
        }
    }
}
