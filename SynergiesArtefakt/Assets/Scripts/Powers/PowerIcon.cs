using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public string effect;
    public Image image;
    private DataHolder dataHolder;



    private bool isEquipped;
    private bool startDragEquipState;
    private Vector2 startPos;
    List<RaycastResult> Targeting = new List<RaycastResult>();

    private void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        startDragEquipState = isEquipped;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Targeting = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, Targeting);
        for (int i = 0; i < Targeting.Count; i++)
        {
            PowerEquipSquare powerEquip = Targeting[i].gameObject.GetComponent<PowerEquipSquare>();
            if (powerEquip != null)
            {
                if (!isEquipped)
                {
                    powerEquip.EquipEffect(gameObject, effect);
                    isEquipped = true;
                }
            }
        }

        if (startDragEquipState == isEquipped)
        {
            transform.position = startPos;
        }
    }



    public void Unequip()
    {
        isEquipped = false;
    }
}
