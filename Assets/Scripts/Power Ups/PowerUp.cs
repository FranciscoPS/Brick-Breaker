using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = -fallSpeed;
    }

    private void OnEnable()
    {
        rb.linearVelocityY = -fallSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ResolvePowerUp();
        }

        gameObject.SetActive(false);
    }
    protected abstract void ResolvePowerUp();
}
