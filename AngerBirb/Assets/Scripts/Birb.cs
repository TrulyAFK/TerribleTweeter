using UnityEngine;

public class Birb : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDrag = 3;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 _startPosition;
    public bool IsDraging {get; private set; }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _startPosition = rb.position;
    }
    void OnMouseDown(){
        IsDraging = true;
        sr.color = Color.red;
    }
    void OnMouseUp(){
        IsDraging=false;
        Vector2 currentPos = rb.position; 
        Vector2 dir = _startPosition-currentPos;
        dir.Normalize();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(dir*_launchForce);
        sr.color = Color.white;
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desirePos = mousePos;
        float dist = Vector2.Distance(desirePos,_startPosition);
        if (dist > _maxDrag)
        {
            Vector2 dir = desirePos-_startPosition;
            dir.Normalize();
            desirePos=_startPosition+(dir*_maxDrag);
        }
        if(desirePos.x > _startPosition.x)
            desirePos.x = _startPosition.x;
        transform.position =desirePos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Dely();
    }
    async void Dely()
    {
        await Awaitable.WaitForSecondsAsync(2.5f);
        rb.position = _startPosition;
        rb.bodyType=RigidbodyType2D.Kinematic;
        rb.linearVelocity=Vector2.zero;
    }
}
