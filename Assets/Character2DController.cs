using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;       //gör så att man kan förändra value enklare - Mikhael
    public bool MoveAccess = true;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    public void Update()
    {
       if (MoveAccess == true) //Gör så att man bara kan hoppa och gå medans MoveAccess är true. - Daniel
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed; //gör så att man kan gå - Mikhael

            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) //gör så att man kan hoppa - Mikhael
            {
                SoundManagerScript.PlaySound("jump");   //spela jumpljud - Mikhael
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
    }
}