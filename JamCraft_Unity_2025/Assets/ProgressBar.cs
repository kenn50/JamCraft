using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProgressBar : MonoBehaviour
{
    public RectTransform container;
    public RectTransform filled;

    public UnityAction on_full;
    public bool full;

 
    public float percent_filled = 0;


    private void Start() {
        full = false;
    }
    // Update is called once per frame
    void Update()
    {

        percent_filled = Mathf.Clamp(percent_filled, 0f, 1f);
        filled.sizeDelta = new Vector2(percent_filled * container.sizeDelta.x, filled.sizeDelta.y);

        if (percent_filled >= 1 && !full) {
            on_full();
            full = true;
        }


    }
}
