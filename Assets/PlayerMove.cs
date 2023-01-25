using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector2 MovementVector;

    public float moveSpeed = 500;

    public event Action<Vector2> OnMovement;

    private Rigidbody2D rb;

    [SerializeField]
    private VirtualJoystickController Joystick;

    //==========================================//
    //              TESTS CLAVIER               //
    //==========================================//
    /**/ float rotation;                      /**/
    /**/ readonly float rotationSpeed = 150f; /**/
    /**/ readonly float speedKeyboard = 50f;  /**/
    //==========================================//

    public void FirePressed()
    {
        Debug.Log("@todo : FirePressed !");
    }
    public void FireReleased()
    {
        // Pas réellement utile ici
        Debug.Log("@todo : FireReleased !");
    }

    private void UseKeyboard()
    {
        // rotation = gauche/droite
        rotation = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, rotation * Time.deltaTime * rotationSpeed * -1);

        // avancer
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * speedKeyboard);
        }

        // stopper
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.zero;
        }

        // Fire!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FirePressed();
        }
    }

    private void Move(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed * Time.deltaTime;

        if (direction.magnitude > 0)
        {
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Joystick.OnMove += Move;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UseKeyboard();
    }
}
