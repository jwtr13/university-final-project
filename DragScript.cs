using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //Need a location to return the dragged gameObject to when the user stops dragging
    //This will be overwritten if the item is over a valid drop area
    public Transform returnLocation = null;

    //Begin Drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Get the location of the original area that the dragged item was
        returnLocation = this.transform.parent;
        //Remove the game object as a child from the area it is in, and make it a child of the main canvas
        //This will let it find a new parent, when the item is dropped
        this.transform.SetParent(GameObject.FindWithTag("MainCanvas").transform);
        //Turn off the raycast blocking, so that the raycast can be used to find what the item is above
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //Drag
    public void OnDrag(PointerEventData eventData)
    {
        //make the dragged item's transform.position the same as the mouse position
        this.transform.position = eventData.position;
    }

    //End Drag
    public void OnEndDrag(PointerEventData eventData)
    {
        //Return the item to it's original location
        this.transform.SetParent(returnLocation);
        //Turn raycast blocking back on
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

