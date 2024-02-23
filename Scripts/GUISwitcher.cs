using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISwitcher : MagnifyingGlass //Declares a GUI Switcher Class
{
    public GameObject SynthGUI; //Declares the SynthGUI game object
    public GameObject DAWGUI; //Declares the DAWGUI game object

    public void SwitchToSynth() //Function to switch to the Synth GUI
    {
        SynthGUI.SetActive(true); //Sets the Synth GUI to active
        DAWGUI.SetActive(false); //Sets the DAW GUI to inactive
        DisableTips();
    }

    public void SwitchToDAW() //Function to switch to the DAW GUI
    {
        DAWGUI.SetActive(true); //Sets the DAW GUI to active
        SynthGUI.SetActive(false); //Sets the Synth GUI to inactive
        DisableTips();
    }
}
