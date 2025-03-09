using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : ProgressBar
{
    Color default_color;
    public Color blinking_color;
    Image filled_image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filled_image = filled.gameObject.GetComponent<Image>();
        default_color = filled_image.color;
        on_full += () => {
            StartCoroutine(blinking());
        };
    }


    IEnumerator blinking() {
        for (int i = 0; i < 5; i++) {

            filled_image.color = blinking_color;
            yield return new WaitForSeconds(0.2f);
            filled_image.color = default_color;
            yield return new WaitForSeconds(0.2f);
        }
        percent_filled = 0;
        full = false;


    }

}
