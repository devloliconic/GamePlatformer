using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionMenu : MonoBehaviour
{

   
   

    // Update is called once per frame
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
