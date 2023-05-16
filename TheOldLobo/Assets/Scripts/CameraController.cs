using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float Smoothing = 0.5f;
    public Transform Player;
    private Vector3 _offset = new Vector3();
    public bool start = false;
    public float duration = 1.0f;
    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SmoothFollow();
    }
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }
    void SimpleFollow()
    {
        transform.position = Player.position + _offset;
    }

    void SmoothFollow()
    {
        Vector3 target = Player.position;
        target.z = -10;
        transform.position = Vector3.Lerp(transform.position, target, Smoothing);
    }
    public IEnumerator Shaking()
    {
        Vector2 startPosition = transform.position;
        float timePassed = 0;
        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitCircle;
            yield return null;
        }
        transform.position = startPosition;
    }
}
