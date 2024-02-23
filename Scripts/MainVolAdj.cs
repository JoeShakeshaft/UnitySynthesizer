using UnityEngine;
using UnityEngine.Audio;

public class MainVolAdj : MonoBehaviour //Declares the class MainVolAdj which inherits from Unity's main behaviour class
{
    [SerializeField] private AudioMixer mainMixer; //Declares a variable which points to the main audio mixer of the program

    public void Start() //Function which runs as soon as the program is opened
    {
        SetVolume(0.22f); //Sets the volume to 0.22 (Suitable base value found through testing)
    }
    public void SetVolume(float sliderValue) //Function which runs each time the GUI slider is moved by the user
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20); //Mathematical calculation to determine appropriate volume adjustment
    }
}


