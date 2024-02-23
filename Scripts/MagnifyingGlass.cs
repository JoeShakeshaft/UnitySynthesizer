using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnifyingGlass : MonoBehaviour
{
    public GameObject textPanel; //Declares text panel
    public Text tooltip; //Declares tooltip
    public GameObject synthButtons; //Declares synth buttons
    public GameObject dawButtons; //Declares daw buttons
    public bool toggled = false; //Declares toggled boolean
    public GameObject synthCanvas; //Declares synth canvas

    public void Update() //Function which runs every frame
    {
        Vector3 cursorPos = Input.mousePosition; //Gets the mouse position
        if (cursorPos.x > 1000) //Checks which side of the screen the mouse is on
        {
            textPanel.transform.position = new Vector2(cursorPos.x, cursorPos.y); //Locks text panel to cursor
        }
        else //If the mouse is on the left
        {
            textPanel.transform.position = new Vector2(cursorPos.x + 700, cursorPos.y); //Locks text panel to cursor and flips its side
        }
    }

    public void EnableTips() //Function to enable tips
    {
        if(toggled == false) //Runs if toggled is false
        {
            if(synthCanvas.activeInHierarchy == true) //Runs if synth canvas is active
            {
                synthButtons.SetActive(true); //Sets the synth buttons to active
            }
            else //Runs if synth canvas isnt active
            {
                dawButtons.SetActive(true); //Sets the daw buttons to active
            }
            textPanel.SetActive(true); //Activates the text panel
            toggled = true; //Sets toggled to true
        }
        else //Runs if toggled is true
        {
            DisableTips(); //Calls DisableTips function
        }
        
    }
    public void DisableTips() //Function to disable tips
    {
        textPanel.SetActive(false); //Sets to inactive
        synthButtons.SetActive(false); //Sets to inactive
        dawButtons.SetActive(false); //Sets to inactive
        toggled = false; //Sets toggled to false
    }
    public void Master()
    {
        tooltip.text = "Adjusts the volume of the synthesized sound post-processing (once all the effects have been added).";
    }
    public void Osc()
    {
        tooltip.text = "An oscillator or sine wave is the most traditional ‘plain’ sounding waveform and tends to sit well in the mix behind other more eccentric sounds.";
    }
    public void Square()
    {
        tooltip.text = "A square wave has a harsh, buzzy tone and has been utilised well in many retro videogame soundtracks. It sounds best at the forefront of the mix with an oscillator sat behind to make up for the texture lost in its boxy nature. ";
    }
    public void Triangle()
    {
        tooltip.text = "A triangle wave is almost a middle ground between the smoothness of an oscillator and the buzz of a square wave. Its bright, quacking sound functions well for stabbing lead lines.";
    }
    public void Echo()
    {
        tooltip.text = "Digital delay sounds similar to the echo heard when shouting in a tunnel, however no sound quality is lost with each repetition. When a note is played, after a period of time that note will be heard again – but quieter. ";
    }
    public void Chorus()
    {
        tooltip.text = "Chorus replicates the sound heard when multiple instruments play the same note at once. This works by duplicating the sound made by the synthesizer and then slightly offsetting the pitch to allow both to be heard and distinguished between, simulating the sound of two people playing at once.";
    }
    public void Reverb()
    {
        tooltip.text = "Reverb is very similar to delay however instead of producing repetitions it produces a prolonged sustain of the sound – creating a spacial effect. The aim of reverb is to simulate a closed ‘space’ such as a room for the sound to travel around. The higher the reverb, the bigger the room. ";
    }
    public void OctMod()
    {
        tooltip.text = "Allows you to change the pitch of each individual waveform.";
    }
    public void Piano()
    {
        tooltip.text = "Above each note here is the letter for a key which, when pressed on your keyboard, will activate that note for as long as the key is held.";
    }
    public void SwitchDAW()
    {
        tooltip.text = "Switches to the DAW GUI screen.";
    }
    public void Mic()
    {
        tooltip.text = "Allows you to select a microphone from all the audio input devices connected to your computer.";
    }
    public void Rec()
    {
        tooltip.text = "Highlights red to indicate that you are recording.";
    }
    public void Play()
    {
        tooltip.text = "Plays the current audio clip stored.";
    }
    public void Record()
    {
        tooltip.text = "Begins recording.";
    }
    public void Stop()
    {
        tooltip.text = "Ends recording.";
    }
    public void Imp()
    {
        tooltip.text = "Allows you to import a WAV clip from the file browser.";
    }
    public void Exp()
    {
        tooltip.text = "Allows you to export a WAV clip to the file browser.";
    }
    public void SwitchSynth()
    {
        tooltip.text = "Switches to the Synthesizer GUI.";
    }
}
