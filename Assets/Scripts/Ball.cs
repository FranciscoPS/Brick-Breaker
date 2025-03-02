using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxXDiff;
    Rigidbody2D rb;
    [HideInInspector] public Vector2 initDirection = Vector2.down;
    float speedMult = 1;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Empujar (Aplicamos una fuerza externa al objeto)
        //rb.AddForce(Vector2.down, ForceMode2D.Impulse); 

        rb.linearVelocity = initDirection * speed * speedMult; //Asignarle una velocidad
    }

    public void SetNewSpeed(float newMult)
    {
        speedMult = newMult;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity  = rb.linearVelocity.normalized * speed * speedMult;
    }

    // Se ejecuta cada vez que se ejecutan las físicas, es decir una vez cada 24 fps
    private void FixedUpdate()
    {
        if(Mathf.Abs(rb.linearVelocityY) <= 0.01)
        {
            rb.linearVelocityY = -5f;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Void"))
        {
            gameObject.SetActive(false);
            return;
        }

        if (!collision.gameObject.CompareTag("Player")) return;

        Vector2 playerPos = collision.gameObject.transform.position;
        Vector2 newDir = (Vector2)transform.position - playerPos;

        if(Mathf.Abs(newDir.x) > maxXDiff) newDir.x = maxXDiff * (newDir.x / Mathf.Abs(newDir.x));

        rb.linearVelocity = newDir.normalized * rb.linearVelocity.magnitude;
    }
}
