using UnityEngine;
using UnityEngine.UI;
public class Cell : PartContainer
{
    public int i, j;
    public int id = -1;

    public GameObject part;
    public Sprite defaultImage;

    public ShipBuilder sb;

    public override void DragBegin()
    {
        if (id != -1) {
            GameObject g = Instantiate(part, GameObject.FindGameObjectWithTag("BuilderCanvas").GetComponent<RectTransform>());
            g.GetComponent<Part_UI>().id = id;
            g.GetComponent<Part_UI>().old = gameObject;
            g.GetComponent<Image>().sprite = GetComponent<Image>().sprite;


            GetComponent<Image>().sprite = defaultImage;
            id = -1;

        }
        

    }


    public override void DragEnd(GameObject g)
    {
        GetComponent<Image>().sprite = g.GetComponent<Image>().sprite;
        id = g.GetComponent<Part_UI>().id;

        sb.shipMatrix[i, j] = id;

    }
}
