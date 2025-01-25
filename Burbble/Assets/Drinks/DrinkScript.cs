using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrinkScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int DrinkValue;
    private Image ImageDrink;
    private Camera CameraMain;
    public bool CanDrag = true;
    public Transform MixerCanvas;
    [HideInInspector] public Transform parentAfterDrag;

    private void Awake() {
        ImageDrink = this.GetComponent<Image>();
        CameraMain = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }
        Debug.Log("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.parent);
        transform.SetAsLastSibling();
        ImageDrink.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }
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
}
