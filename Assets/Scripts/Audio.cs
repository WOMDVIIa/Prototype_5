using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public float volume;
    
    private Slider sliderUI;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    private static Audio instance = null;
    public static Audio Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //public void ChangeVolume()
    //{
    //    if (sliderUI == null)
    //    {
    //        sliderUI = GameObject.Find("Volume Slider").GetComponent<Slider>();
    //    }
    //    AudioListener.volume = sliderUI.value;
    //}



    //private void Update()
    //{
    //    AudioListener.volume = volume;
    //}
}