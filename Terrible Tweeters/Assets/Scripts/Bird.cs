using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition; // get mouse position in the screen space (x, y)
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // set z value of mouse position to match bird's z location in screen space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); // convert updated screen position (with correct z) to world space coordinates
        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z); // update bird's position to follow the mouse


        /*
        // bird snapped to the origin when clicked and wouldn't move
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
