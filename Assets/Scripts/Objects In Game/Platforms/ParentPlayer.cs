﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayer : MonoBehaviour
{
    [SerializeField]
    bool onlyOnTop;

    [SerializeField, Range(.1f, 1f)]
    float CollisionOffset = .2f;
    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player" && !onlyOnTop)
        {
            col.transform.parent = transform;
        }
        if(col.gameObject.tag == "Player" && onlyOnTop)
        {
           if( col.transform.position.y > transform.position.y + CollisionOffset)
            {
                col.transform.parent = transform;
            }
            else if(col.transform.position.y < transform.position.y + CollisionOffset)
            {
                col.transform.parent = null;
            }
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
        }
    }
}
