using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Camera cam;
    Vector3 mousePos;
    public GlobalClick globalClick;
    public Vector3 homePos;
    public bool overSellCollider;
    public bool movingHome;
    private void Awake()
    {
        cam = Camera.main;
        homePos = transform.position;
    }

    private Vector3 GetMousPos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousPos();
    }

    private void OnMouseDrag()
    {
        if (globalClick.isDragging)
        {
            transform.position = cam.ScreenToWorldPoint(Input.mousePosition - mousePos);
        }       
    }

    private void OnMouseUp()
    {
        if (globalClick.isDragging)
        {
            movingHome = true;
        }     
        if (overSellCollider)
        {
            globalClick.SellClicks();
        }
        transform.position = homePos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sell")
        {
            overSellCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overSellCollider = false;
    }
}
