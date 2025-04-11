using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30f;
    [SerializeField] Toggle _toggle;
    private bool _disableToggleEvent;
    private float _previousVolume = 1f;

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
            _slider.value = _previousVolume; //restore previous volume
        }

        else
        {
            _previousVolume = _slider.value; //save current volume
            _slider.value = _slider.minValue;
        }

    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    private void HandleSliderValueChanged(float value)
    {
        if(value == _slider.minValue)
        {
            _mixer.SetFloat(_volumeParameter, -80f);
        }
        else
        {
            _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
        }
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
