using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Part_UI : MonoBehaviour
{

    public bool holding;
    public int id = -1;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Camera uiCamera;
    private CanvasGroup canvasGroup;
    public GameObject old;

    void Start()
    {
        

        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        // Get or add a CanvasGroup component
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        // Disable blocking raycasts when holding
        canvasGroup.blocksRaycasts = false;

        // Get the camera used for the UI
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            uiCamera = null; // No camera needed for overlay
        }
        else
        {
            uiCamera = canvas.worldCamera;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector2 mousePosition = Input.mousePosition;

        // Convert mouse position to UI position
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            rectTransform.position = mousePosition;
        }
        else
        {
            // For Screen Space Camera or World Space
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.GetComponent<RectTransform>(),
                mousePosition,
                uiCamera,
                out localPoint);

            rectTransform.localPosition = localPoint;
            
        }
        GetComponent<Image>().enabled = true;

        if (Input.GetMouseButtonUp(0))
        {
            //Get an object reference to the highlighted object
            GameObject hoveredObject = GetObjectUnderMouse();

            GameObject snap = old;
            if (hoveredObject != null && hoveredObject.GetComponent<Cell>() != null)
            {
                if (hoveredObject.GetComponent<Cell>().id == -1) snap = hoveredObject;
            }

            snap.GetComponent<PartContainer>().DragEnd(gameObject);

            Destroy(gameObject);
        }
        

    }

    // Method to get the GameObject under the mouse cursor
    private GameObject GetObjectUnderMouse()
    {
        // Create a pointer event data with the current mouse position
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        // Clear the list and raycast
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        // If we hit something, return the first valid result
        if (raycastResults.Count > 0)
        {
            // Skip the first result if it's this object
            for (int i = 0; i < raycastResults.Count; i++)
            {
                if (raycastResults[i].gameObject != this.gameObject)
                {
                    return raycastResults[i].gameObject;
                }
            }
        }

        return null;
    }
}