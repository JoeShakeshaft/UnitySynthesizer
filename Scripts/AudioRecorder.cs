using SFB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioRecorder : MonoBehaviour //Declares the audio recorder class
{
    //MENU
    public Dropdown micDropdown; //Declares a pointer to the dropdown menu on the GUI
    public Text recordingText; //Declares a pointer to the recording text on the GUI

    //RECORDING
    public AudioSource audioSource; //Declares the audio source
    private string deviceName; //Declares a string which holds the device name

    private void Start() //Function which runs when the program starts
    {
        List<string> micOptions = new List<string>(); //Declares a list to hold the microphone options
        foreach (var device in Microphone.devices) //Iterates for each microphone device detected
        {
            micOptions.Add(device); //Adds the detected device to the list
        }

        micDropdown.ClearOptions(); //Clears the dropdown
        micDropdown.AddOptions(micOptions); //Adds the options from the list to the drop down

        deviceName = micDropdown.options[micDropdown.value].text; //Sets the device name to the first option in the dropdown
    }

    public void Refresh() //Function which runs each time a dropdown option is selected
    {
        micDropdown.RefreshShownValue(); //Refreshes the displayed value of the dropdown to match the users selection
        deviceName = micDropdown.options[micDropdown.value].text; //Sets the device name to the new dropdown option selected
    }

    public void Record() //Function which runs when the record button is pressed
    {
        audioSource.clip = Microphone.Start(deviceName, false, 120, 48000); /*Begins recording on the selected device
                                                                           the false declaration ensures that the clip
                                                                           doesn't loop over itself, 120 is the maximum
                                                                           number of seconds for which the clip will
                                                                           record and 48000 is the sampling rate*/
        recordingText.color = new Color32(255, 0, 0, 255); //Changes the colour of the text using RGB values
    }
    
    public void Play() //Function which runs when the play button is pressed
    {
        audioSource.Play(); //Plays the recorded clip
    }
    public void End() //Function which runs when the end button is pressed
    {
        Microphone.End(deviceName); //Ends the current recording before the limit is reached
        audioSource.Stop(); //Stops playback from the audio source
        recordingText.color = new Color32(118, 58, 58, 255); //Changes the colour of the text using RGB values
    }

    public void Import() //Function which imports tracks when the import button is pressed
    {
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open File", Application.persistentDataPath, "wav", false);
        //Displays the file browser to the user and returns a list of paths of files selected
        string path = paths[0]; //Chooses the first item from the list (as the user should only pick 1 path)
        audioSource.clip = WavUtility.ToAudioClip(path); //Makes the current clip the imported file
    }
        public void Export() //Function which exports audio tracks when the export button is pressed
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Save File", Application.persistentDataPath, "", "wav");
        //Displays the file browser to the user and returns the path and name selected by the user
        byte[] wavData = WavUtility.FromAudioClip(audioSource.clip); //Compresses and reformats the audio clip into a WAV
        File.WriteAllBytes(path, wavData); //Exports the newly made WAV file to the correct location
    }
}
