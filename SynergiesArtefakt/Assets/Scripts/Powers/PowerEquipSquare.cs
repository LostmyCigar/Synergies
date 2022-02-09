using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerEquipSquare : MonoBehaviour
{
    public int equipslot;
    public DataHolder dataHolder;
    [SerializeField] private Image panel;
    public GameObject equippedEffect;


    private void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
    }
    public void EquipEffect(GameObject icon, string ballEffect)
    {

        Unequip(equippedEffect);


        equippedEffect = icon;
        icon.transform.SetParent(transform);
        icon.transform.position = transform.position;


        dataHolder.EquippEffect(equipslot, ballEffect);
    }

    public void Unequip(GameObject equipped)
    {

        if (equippedEffect != null)
        {
            equipped.transform.SetParent(panel.transform);
            equipped.GetComponent<PowerIcon>().Unequip();
            equippedEffect = null;
        }

    }
}
