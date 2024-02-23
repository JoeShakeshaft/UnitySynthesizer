using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Oscillator : MonoBehaviour /*Sets up the oscillator class 
                                        which inherits from Unity's main behaviours */
{   
    //WAVE
    public double frequency = 440.0; /*Declares the variable frequency and assigns it as 440
                                     - determines the pitch of the sound produced */
    public double increment; /*Declares the variable increment
                              - determines how much the phase will increase per cycle */
    public double phase; /*Declares the variable phase
                          - determines the current amplitude of the wave */
    public double sampling_rate = 48000.0; /*Declares the variable sampling rate
                                            and assigns it as 48000 -
                                            determines the quality of the sound produced*/

    //VOLUME
    public float gain; //Declares the variable gain - determines the current volume of the wave
    private float volume = 0.22f; /*Declares the variable volume
                                 - determines the volume to which the wave will increase
                                 when a key is pressed */

    //AUDIO OUTPUT
    public AudioSource source; //Declares the main Audio Source of the user

    //OCTAVE MODULATION
    private float octave = 0; /*Declares the variable octave
                             - for each increment or decrement the frequency is doubled or halved */

    //KEYBOARD HIGHLIGHTS
    public GameObject highlights; /*Declares the variable highlights which holds an empty
                                  game object which is a parent to all the seperate
                                  highlight boxes*/

    public void Start() //Function which runs as soon as the program is opened
    {
        source = GetComponent<AudioSource>(); //Declares a variable which holds the audio source component
        source.Play(0); //Initialises the audio source - making it output sound to the user indefinitely
    }

    public void Update() //Function which runs once for every frame of the programs execution
    {
        gain = 0f; //Sets the value within the variable gain to 0
        
        for (int i = 0; i <= 14; i++) //For loop from 0 to 14
        {
            highlights.transform.GetChild(i).gameObject.SetActive(false); /*Sets all the children of the GameObject
                                                                          highlight to be inactive*/
        }

        if (Input.GetKey(KeyCode.A)) //Runs if the user is pressing the A key
        {
            playNote(440); //A
            highlights.transform.GetChild(0).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.W)) //Runs if the user is pressing the W key
        {
            playNote(466); //A#
            highlights.transform.GetChild(1).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.S)) //Runs if the user is pressing the S key
        {
            playNote(494); //B
            highlights.transform.GetChild(2).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.D)) //Runs if the user is pressing the D key
        {
            playNote(523); //C
            highlights.transform.GetChild(3).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.R)) //Runs if the user is pressing the R key
        {
            playNote(554); //C#
            highlights.transform.GetChild(4).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.F)) //Runs if the user is pressing the F key
        {
            playNote(587); //D
            highlights.transform.GetChild(5).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.T)) //Runs if the user is pressing the T key
        {
            playNote(622); //D#
            highlights.transform.GetChild(6).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.G)) //Runs if the user is pressing the G key
        {
            playNote(659); //E
            highlights.transform.GetChild(7).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.H)) //Runs if the user is pressing the H key
        {
            playNote(698); //F
            highlights.transform.GetChild(8).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.U)) //Runs if the user is pressing the U key
        {
            playNote(739); //F#
            highlights.transform.GetChild(9).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.J)) //Runs if the user is pressing the J key
        {
            playNote(783); //G
            highlights.transform.GetChild(10).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.I)) //Runs if the user is pressing the I key
        {
            playNote(830); //G#
            highlights.transform.GetChild(11).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.K)) //Runs if the user is pressing the K key
        {
            playNote(880); //High A
            highlights.transform.GetChild(12).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.O)) //Runs if the user is pressing the O key
        {
            playNote(932); //High A#
            highlights.transform.GetChild(13).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
        if (Input.GetKey(KeyCode.L)) //Runs if the user is pressing the L key
        {
            playNote(988); //High B
            highlights.transform.GetChild(14 ).gameObject.SetActive(true); /*Sets the child corresponding to the key press
                                                                         in highlights as active*/
        }
    }

    public virtual void OnAudioFilterRead(float[] data, int channels) /*Function which runs each time audio is updated
                                                       similar to update function but volume activated*/
    {
        increment = frequency * 2.0 * Mathf.PI / sampling_rate; /*Sets the increment to the frequency
                                                                multiplied by 2 times Pi divided by the
                                                                sampling rate*/

        for(int i = 0; i < data.Length; i += channels) /*Runs from 0 to the length  of the data inputted
                                                       in steps of i + the current channels*/
        {
            phase += increment; //The phase increases by the value of increment
            data[i] = (float)(gain * Mathf.Sin((float)phase)); /*The current element in the data array becomes
                                                               the gain multiplied by the Sine of phase*/

            if(channels == 2) //Runs if channels = 2
            {
                data[i + 1] = data[i]; //The value of the current data element is duplicated to the next
            }

            if(phase > (Mathf.PI * 2)) //Runs if the current phase is greater than Pi times 2
            {
                phase = 0.0; //Phase is reset to 0
            }
        }
    }

    public void playNote(float freq) //Defines the play note function
    {
        gain = volume; //Makes the current gain equal to the volume set by the user
        frequency = freq * Mathf.Pow(2, octave); /*Makes frequency the value passed into the function
                                                 multiplied by 2 to the power of the octave value*/
    }

    public void adjustVolume(float newVol) //Function to adjust the volume based on the position of the slider
    {
        volume = newVol; //Sets the volume to the value of the slider
    }

    public void setOctave(float oct) //Function to adjust the octave based on the position of the slider
    {
        octave = oct; //Sets the octave to the value of the slider
    }
}
