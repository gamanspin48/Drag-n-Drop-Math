using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private bool isDragging;
    public string tagParent;
    public bool isOnParent;
    public Vector3 originalPosition;

    public void Start(){
        originalPosition = gameObject.transform.position;
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        if (!isOnParent){
            gameObject.transform.position = originalPosition;
        }
    }

    void Update()
    {
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        isOnParent = col.gameObject.tag == tagParent;  
    }

    void OnTriggerExit2D(Collider2D col)
    {   
        if (col.gameObject.tag == tagParent)
            isOnParent = false;
    }
}