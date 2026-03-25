using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer _lineRenderer;
    Birb _birb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _birb = FindAnyObjectByType<Birb>();
        _lineRenderer.SetPosition(0,_birb.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_birb.IsDraging)
        {
            _lineRenderer.enabled=true;
            _lineRenderer.SetPosition(1,_birb.transform.position);
        }else{
            _lineRenderer.enabled=false;
        }
    }
}
