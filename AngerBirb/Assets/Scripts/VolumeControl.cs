using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public string _volumeParameter;
    public AudioMixer _mixer;
    public Slider _slider;
    public Toggle _toggle;
    float _multiplier=30;
    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSlider);
        _toggle.onValueChanged.AddListener(HandleToggle);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter,_slider.value);
    }
    private void HandleSlider(float value)
    {
        _mixer.SetFloat(_volumeParameter,value:Mathf.Log10(value)*_multiplier);
    }
    private void HandleToggle(bool enableSound)
    {
        if (enableSound)
        {
            _mixer.SetFloat(_volumeParameter,_slider.value);
            _slider.enabled=true;
        } else
        {
            _mixer.SetFloat(_volumeParameter,-80f);
            _slider.enabled=false;
        }
    }
    void Start()
    {
        _slider.value=PlayerPrefs.GetFloat(_volumeParameter,_slider.value);
    }
}
