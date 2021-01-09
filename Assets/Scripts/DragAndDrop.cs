using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private bool isDragging;
    public string tagParent;
    public bool isOnParent;
    public Vector3 originalPosition;
    public GameObject collider2D;
    private bool isHome;

    public void Start(){
        originalPosition = gameObject.transform.position;
        isHome = true;
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
        }else{
            originalPosition = gameObject.transform.position;
            gameObject.transform.parent = collider2D.transform;
            if (isHome){
                isHome = false;
                if (tagParent == "mainboard"){
                    MainOperasi.Instance.SpawnObjectPiring();
                }else{
                    MainOperasi.Instance.SpawnObjectApple();
                }
            }
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
        if (col.gameObject.tag == tagParent){
            isOnParent = true;
            collider2D = col.gameObject;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {   
        if (col.gameObject.tag == tagParent){
            isOnParent = false;
        }
    }
}