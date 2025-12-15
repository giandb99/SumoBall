using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector2 initialPosition;
    private Rigidbody2D rig;
    private float respawnDelay = 1.0f;

    void Start()
    {
        initialPosition = transform.position;

        rig = GetComponent<Rigidbody2D>();
        if (rig == null)
            Debug.LogError("PlayerRespawn necesita un componente Rigidbody2D en el mismo objeto.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
            DieAndRespawn();
    }

    private void DieAndRespawn()
    {
        rig.isKinematic = true;
        transform.position = initialPosition;
        rig.velocity = Vector2.zero;

        Invoke("ActivatePlayer", respawnDelay);
        Debug.Log(gameObject.name + " ha muerto y reaparece en " + initialPosition.ToString());
    }

    private void ActivatePlayer()
    {
        rig.isKinematic = false;
    }
}