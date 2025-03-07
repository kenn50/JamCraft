using UnityEngine;
using UnityEngine.UI;

public class BuyPart : PartContainer
{
    public override void DragBegin()
    {
        if (id != -1)
        {
            GameObject g = Instantiate(part, GameObject.FindGameObjectWithTag("BuilderCanvas").GetComponent<RectTransform>());
            g.GetComponent<Part_UI>().id = id;
            g.GetComponent<Part_UI>().old = gameObject;
            g.GetComponent<Image>().sprite = GetComponent<Image>().sprite;



        }


    }


    public override void DragEnd(GameObject g)
    {
        GetComponent<Image>().sprite = g.GetComponent<Image>().sprite;
        id = g.GetComponent<Part_UI>().id;

        sb.shipMatrix[i, j] = id;

    }
}
