using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField] private LayerMask paltformLayerMask;
    public float Speed;
    public float jumpSpeed;
    public float fallMultiplier;
    private float input;
    private Rigidbody rgb;
    private Animator heroAnim;
    private SpriteRenderer heroSprite;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        heroAnim = GetComponent<Animator>();
        heroSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        if (input>0 || input<0)
        {
            
            heroAnim.SetBool("Running", true);
        }
        else
        {
            heroAnim.SetBool("Running", false);
        }
        if (input<0)
        {
            heroSprite.flipX = true;
        }
        if (input>0)
        {
            heroSprite.flipX = false;
        }
        rgb.velocity = new Vector3(input * Speed, rgb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            
            rgb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }
        if (rgb.velocity.y<0)
        {
            rgb.velocity += Vector3.up * (Physics2D.gravity.y) * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (!IsGrounded())
        {
            heroAnim.SetBool("Jumping", true);
        }
        else
        {
            heroAnim.SetBool("Jumping", false);
        }
    }
    private bool IsGrounded()
    {
        float extension = 0.1f;
        Color rayColor;
        RaycastHit2D raycastHit= Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extension,paltformLayerMask);
        if (raycastHit.collider!=null)
        {
            rayColor = Color.green;
            
        }
        else
        {
            rayColor = Color.red;
            
        }
        Debug.DrawRay(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + extension),rayColor);
        return raycastHit.collider != null;
    }
}
