﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : IT
{
    public ITEM item;

    public override void Interact()
    {
        base.Interact();        
        Pick();
    }    


    void Pick()
    {
        Debug.Log("use Item : " + item.name);

        Destroy(gameObject);
    }
}