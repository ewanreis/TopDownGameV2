using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class playerController : MonoBehaviour
{   private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private void Start()
    {   boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {   float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        // Swap sprite direction
        if(moveDelta.x > 0)
        {   flip = false;
        }else if (moveDelta.x < 0)
        {   flip = true;
        }

        // Prevent Going inside colliders y
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y)
            , Mathf.Abs(moveDelta.y * Time.deltaTime)
            , LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {   // Movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        
        // Prevent Going inside colliders x
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.x)
            , Mathf.Abs(moveDelta.x * Time.deltaTime)
            , LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {   // Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
