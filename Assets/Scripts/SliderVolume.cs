using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public Slider sliderUI;

    // Start is called before the first frame update
    void Start()
    {
        sliderUI = GameObject.Find("Volume Slider").GetComponent<Slider>();
        sliderUI.onValueChanged.AddListener(delegate { ChangeVolume(); });
        sliderUI.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeVolume()
    {
        AudioListener.volume = sliderUI.value;
        Debug.Log("slider val = " + sliderUI.value);
    }
}
