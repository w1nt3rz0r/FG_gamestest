using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorPrefab;
    private bool isActive;

    public void Initialize()
    {
        isActive = true;
        // Projectiles that have a parabole, force added only once, not every frame
        projectileBody.AddForce(transform.forward * 700f + transform.up * 300f);
    }

    void Update()
    {
        if (isActive)
        {
            // Projectiles that go in a straight line, position change every frame
            // Movement with the rigid body
            // projectileBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            // Or this code, movement with the transform
            //transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;
    }

}
