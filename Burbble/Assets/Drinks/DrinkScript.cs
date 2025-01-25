using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrinkScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int DrinkValue;
    public Image ImageDrink;
    public Camera CameraMain;
    [HideInInspector] public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        ImageDrink.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
         Vector3 screenPosition = Input.mousePosition;

        screenPosition.z = CameraMain.WorldToScreenPoint(transform.position).z;
        transform.position = CameraMain.ScreenToWorldPoint(screenPosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        transform.SetParent(parentAfterDrag);
        ImageDrink.raycastTarget = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
