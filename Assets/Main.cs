using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private const float maxIntensity = 50;
    private float saveIntensity = 0;
    private static float changeIntensity = 0;
    private static float refreshTime = 1;
    private float sum = 0;
    private static float starttime = 60;
    private static float ontime = 0;
    private bool LeftRight = false;
    private static bool Enabled = false;
    public Light lightOne;
    public Light lightTwo;
    public Scrollbar Intensity, SessionLength, RefreshTime;
    public GameObject settingPanel;
    public Color Changing = Color.white;
    public static Color color = Color.white;
    public void Start()
    {
        settingPanel.SetActive(false);
    }
    public void On()
    {
        if (!Enabled)
        {
            ontime = starttime;
            Enabled = true;
        }
        else Enabled = false;
        
    }
    public void SetIntensity() { changeIntensity = Intensity.value * maxIntensity; }
    public void SetSession() { starttime = (SessionLength.value + 1) * 60; }
    public void SetRefreshtime() { refreshTime = (RefreshTime.value + 1) * 3; }
    public void SetColor() { color = Changing; }
    public void ToggleMenuVisibility() { settingPanel.SetActive(!settingPanel.activeSelf); }
    public void Update()
    {
        if (Enabled)
        {
            if (color != Color.white)
                lightOne.color = lightTwo.color = color;
            if (changeIntensity > 0)
            {
                if (lightOne.intensity <= 0)
                    lightOne.intensity = changeIntensity;
                if (lightTwo.intensity <= 0)
                    lightTwo.intensity = changeIntensity;
            }
            ontime -= Time.deltaTime;
            sum += Time.deltaTime;
            if (sum >= refreshTime && LeftRight)
            {
                saveIntensity = lightOne.intensity;
                lightOne.intensity = 0;
                lightTwo.intensity = saveIntensity;
                LeftRight = false;
                sum = 0;
            }
            else
            if (sum >= refreshTime && !LeftRight)
            {
                saveIntensity = lightTwo.intensity;
                lightOne.intensity = saveIntensity;
                lightTwo.intensity = 0;
                LeftRight = true;
                sum = 0;
            }
            else
            if (ontime <= 0)
                Enabled = false;
            else Debug.Log("Error");
        }
    }

}