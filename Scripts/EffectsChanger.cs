using UnityEngine;
using UnityEngine.Audio;

public class EffectsChanger : MonoBehaviour //Declares the class EffectsChanger which inherits from Unity's main behaviour class
{
    [SerializeField] private AudioMixer mainMixer; //Declares a variable which stores the location of the main audio mixer

    private bool echo_toggled = false; //Declares a boolean which determines whether echo is currently toggled
    private bool chorus_toggled = false; //Declares a boolean which determines whether chorus is currently toggled
    private bool reverb_toggled = false; //Declares a boolean which determines whether reverb is currently toggled

    public GameObject echo_on; //Declares a variable which stores the GUI text that displays when the echo is on
    public GameObject chorus_on; //Declares a variable which stores the GUI text that displays when the chorus is on
    public GameObject reverb_on; //Declares a variable which stores the GUI text that displays when the reverb is on

    public void Start() //Function which runs as soon as the program is opened
    {
        mainMixer.SetFloat("Delay", 1); //Initialises the delay effect to be off in the mixer
        mainMixer.SetFloat("Chorus", 0); //Initialises the chorus effect to be off in the mixer
        mainMixer.SetFloat("Reverb", 0.1f); //Initialises the reverb effect to be off in the mixer
    }
    public void toggleEcho() //Function to toggle the echo effect on and off
    {
        if (echo_toggled == true) //Runs if the echo is currently on
        {
            mainMixer.SetFloat("Delay", 1); //Turns the delay off
            echo_toggled = false; //Inverts the boolean
            echo_on.SetActive(false); //Deactivates the GUI text
        }
        
        else //Runs if the echo is currently off
        {
            mainMixer.SetFloat("Delay", 115); //Turns the delay on
            echo_toggled = true; //Inverts the boolean
            echo_on.SetActive(true); //Activates the GUI text
        }
    }

    public void toggleChorus() //Function to toggle the chorus effect on and off
    {
        if(chorus_toggled == true) //Runs if the chorus is currently on
        {
            mainMixer.SetFloat("Chorus", 0); //Turns the chorus off
            chorus_toggled = false; //Inverts the boolean
            chorus_on.SetActive(false); //Deactivates the GUI text
        }

        else //Runs if the chorus is currently off
        {
            mainMixer.SetFloat("Chorus", 1); //Turns the chorus on
            chorus_toggled = true; //Inverts the boolean
            chorus_on.SetActive(true); //Activates the GUI text
        }
    }

    public void toggleReverb() //Function to toggle the reverb effect on and off
    {
        if(reverb_toggled == true) //Runs if the reverb is currently on
        {
            mainMixer.SetFloat("Reverb", 0.1f); //Turns the reverb off
            reverb_toggled = false; //Inverts the boolean
            reverb_on.SetActive(false); //Deactivates the GUI text
        }

        else //Runs if the reverb is currently on
        {
            mainMixer.SetFloat("Reverb", 10); //Turns the reverb on
            reverb_toggled = true; //Inverts the boolean
            reverb_on.SetActive(true); //Activates the GUI text
        }
    }
}
