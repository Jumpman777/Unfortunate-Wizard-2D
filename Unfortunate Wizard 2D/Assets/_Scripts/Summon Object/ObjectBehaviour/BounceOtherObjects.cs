using UnityEngine;

public class BounceOtherObjects : ObjectBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            Vector2 reflectedDirection = Vector2.Reflect(collision.relativeVelocity, normal);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = reflectedDirection;
        }
    }
}