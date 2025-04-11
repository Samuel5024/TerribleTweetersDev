using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParamter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30f;
    [SerializeField] Toggle _toggle;
    private bool _disableToggleEvent;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
        _toggle.onValueChanged.AddListener(HandleToggleValueChangesd);
    }

    private void HandleToggleValueChangesd(bool enableSound)
    {
        if(_disableToggleEvent)
        {
            return;
        }

        if (enableSound)
        {
            _slider.value = _slider.maxValue;
        }

        else
        {
            _slider.value = _slider.minValue;
        }

    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParamter, _slider.value);
    }

    private void HandleSliderValueChanged(float value)
    {
        _mixer.SetFloat(_volumeParamter, Mathf.Log10(value) * _multiplier);
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParamter, _slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
