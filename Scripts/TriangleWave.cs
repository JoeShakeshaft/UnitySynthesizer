using UnityEngine;
using UnityEngine.UI;

public class TriangleWave : Oscillator /*Sets up the triangle wave class 
                                        which inherits from Oscillator*/
{
    public override void OnAudioFilterRead(float[] data, int channels) /*Function which runs each time audio is updated
                                                       similar to update function but volume activated*/
    {
        increment = frequency * 2.0 * Mathf.PI / sampling_rate; /*Sets the increment to the frequency
                                                                multiplied by 2 times Pi divided by the
                                                                sampling rate*/

        for (int i = 0; i < data.Length; i += channels) /*Runs from 0 to the length  of the data inputted
                                                       in steps of i + the current channels*/
        {
            phase += increment; //The phase increases by the value of increment
            
            data[i] = (float)(gain * (double) Mathf.PingPong ((float) phase, 1.0f)); /*The current data
            element becomes the gain multiplied by the PingPong which is essentially just an increment
            and decrement of 1 up and down, per iteration, of the phase*/

            if (channels == 2) //Runs if channels = 2
            {
                data[i + 1] = data[i]; //The value of the current data element is duplicated to the next
            }

            if (phase > (Mathf.PI * 2)) //Runs if the current phase is greater than Pi times 2
            {
                phase = 0.0; //Phase is reset to 0
            }
        }
    }
}
