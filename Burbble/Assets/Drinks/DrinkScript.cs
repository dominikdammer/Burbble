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

        GameObject targetObject = GameObject.Find("CanvasMixer");

        if (targetObject != null)
        {
            MixerCanvas = targetObject.transform;
            //Debug.Log("Found Transform of TargetObject at: " + MixerCanvas.position);
        }
        else
        {
            //Debug.LogError("TargetObject not found in the scene!");
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }
        //Debug.Log("begin drag");
        //transform.parent.GetComponent<Image>().enabled = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(MixerCanvas);
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
        //Debug.Log("end drag");
        //parentAfterDrag.gameObject.GetComponent<Image>().enabled = true;
        transform.SetParent(parentAfterDrag);
        if (!CanDrag)
        {
            ImageDrink.raycastTarget = false;
        }
        else
        {
            ImageDrink.raycastTarget = true;
        }
        
    }

    public void ResetDrink()
    {
        DrinkValue = 0;
       // parentAfterDrag.gameObject.GetComponent<Image>().enabled = true;
        Destroy(gameObject);
    }
}
