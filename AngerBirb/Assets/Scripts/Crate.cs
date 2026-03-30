using JetBrains.Annotations;
using UnityEngine;

public class Crate : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude < 2f)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("Collision was too slow");
        }
    }
}
