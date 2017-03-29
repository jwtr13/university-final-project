using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZoneScript : MonoBehaviour, IDropHandler
{

    //int to see how many children a gameobject has
    int children;
    //int to set maximum number of children a gameobject can have
    public int maxChildren;

    public void OnDrop(PointerEventData eventData)
    {
        //find out how many children the potential dropzone has
        children = this.transform.childCount;
        //Find the item to be dropped, and change the returnLocation to be the Drop Area
        DragScript drag = eventData.pointerDrag.GetComponent<DragScript>();
        //make sure script is there, and that the maximum number of children has not been reached
        if (drag != null && children < maxChildren)
        {
            //make the item being dragged a child of the drop area
            drag.returnLocation = this.transform;
        }
    }
}

