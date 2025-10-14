using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    public Text vt;


    static bool controlled_volume = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        Mathf.Clamp(AudioListener.volume, 0f, 1f);
        if (!controlled_volume) AudioListener.volume = 0.1f;
    }

    void Update()
    {
        vt.text = "Volume: " + Mathf.Round(AudioListener.volume*100f) + "% \n(O/P) - Control";
        if (Input.GetKeyDown(KeyCode.O))
        {
            controlled_volume = true;
            AudioListener.volume = Mathf.Clamp(AudioListener.volume -= 0.03f, 0f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            controlled_volume = true;
            AudioListener.volume = Mathf.Clamp(AudioListener.volume += 0.03f, 0f, 1f);
        }

    }



}
