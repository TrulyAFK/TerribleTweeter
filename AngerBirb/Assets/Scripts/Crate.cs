using JetBrains.Annotations;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public AudioClip[] _clips;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude < 2f)
        {
            var clip = _clips[Random.Range(0, _clips.Length)];
            GetComponent<AudioSource>().pitch = Random.Range(0.1f, 2f);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("Collision was too slow");
        }
    }
}
