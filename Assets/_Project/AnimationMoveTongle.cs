using System.Collections;
using _Project._Screpts.Screens.SettingsScreen;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class AnimationMoveTongle : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textDisabled;
    [SerializeField] private float _leftPadding = 50f;
    [SerializeField] private float _rightPadding = 25f;
    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private SettingsScreen _settingsScreen;

    private void OnEnable()
    {
        _settingsScreen.OnSoundValueChanged += MoveToggle;
    }

    private void Start()
    {
        StartCoroutine(SetInitialPosition());
        SwitchText();
    }

    private IEnumerator SetInitialPosition()
    {
        yield return new WaitForEndOfFrame();

        UpdatePositionInstant(_settingsScreen.SoundValue);
    }

    public void MoveToggle(bool value)
    {
        UpdatePositionAnimated(value);
        SwitchText();
    }

    private void UpdatePositionAnimated(bool value)
    {
        float targetX = CalculateTargetX(value);
        _rectTransform.DOAnchorPosX(targetX, _animationDuration).SetEase(Ease.OutQuad);
    }

    private void UpdatePositionInstant(bool value)
    {
        float targetX = CalculateTargetX(value);
        _rectTransform.anchoredPosition = new Vector2(targetX, _rectTransform.anchoredPosition.y);
    }

    private float CalculateTargetX(bool value)
    {
        float containerWidth = _rectTransform.parent.GetComponent<RectTransform>().rect.width;

        if (value)
            return containerWidth / 2 - _rightPadding - _rectTransform.rect.width / 2;

        return -containerWidth / 2 + _leftPadding + _rectTransform.rect.width / 2;
    }

    private void SwitchText()
    {
        _textActive.gameObject.SetActive(_settingsScreen.SoundValue);
        _textDisabled.gameObject.SetActive(!_settingsScreen.SoundValue);
    }

    private void OnDisable()
    {
        _settingsScreen.OnSoundValueChanged -= MoveToggle;
    }
}