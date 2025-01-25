using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Image ImageIngredient;
    private Camera CameraMain;
    public int Value;
    public Transform IngredientCanvas;
    [HideInInspector] public Transform parentAfterDrag;

    private void Awake() {
        ImageIngredient = this.GetComponent<Image>();
        CameraMain = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(IngredientCanvas);
        transform.SetAsLastSibling();
        ImageIngredient.raycastTarget = false;
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
        ImageIngredient.raycastTarget = true;
    }
}
