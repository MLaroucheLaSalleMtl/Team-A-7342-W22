using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IDeselectHandler, IPointerDownHandler

{
    private Selectable itemSelected;

    public void OnDeselect(BaseEventData eventData)//Move the selection with the keyboard
    {
        itemSelected.OnPointerExit(null);
    }

    public void OnPointerDown(PointerEventData eventData)//Execute the button press on(press)
    {
        if (eventData.selectedObject.GetComponent<Button>() != null)
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData) //Move cursor on top of a button
    {
        itemSelected.Select();
    }

    // Start is called before the first frame update
    void Start()
    {
        itemSelected = GetComponent<Selectable>();
    }
}
