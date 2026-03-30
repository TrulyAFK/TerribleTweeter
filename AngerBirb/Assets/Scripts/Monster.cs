using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _dead;
    [SerializeField] ParticleSystem _effect;

    bool _hasDied;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Start()
    {
        while (_hasDied == false)
        {
            float delay = UnityEngine.Random.Range(5, 30);
            yield return Awaitable.WaitForSecondsAsync(delay);
            if (!_hasDied)
                GetComponent<AudioSource>().Play();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDie(collision))
        {
            Die();
        }
        
    }

    async void Die()
    {
        _hasDied=true;
        GetComponent<SpriteRenderer>().sprite=_dead;
        _effect.Play();
        await Awaitable.WaitForSecondsAsync(1);
        gameObject.SetActive(false);
    }

    bool ShouldDie(Collision2D collision)
    {
        if(_hasDied)
            return false;
        Birb bird = collision.gameObject.GetComponent<Birb>();
        if (bird != null)
            return true;
        if (collision.contacts[0].normal.y < -0.5)
            return true;
        return false;
    }
}
