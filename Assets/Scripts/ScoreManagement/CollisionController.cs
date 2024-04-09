using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "prefab")
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position, 1f);
            Destroy(gameObject);
        }
    }
}
