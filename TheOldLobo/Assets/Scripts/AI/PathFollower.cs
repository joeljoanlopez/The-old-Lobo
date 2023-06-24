using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Waypoint _waypoints;
    [SerializeField] float _speed = 2f;
    [SerializeField] float _distChange = 0.01f;
    Animator animator;

    Transform _currentWP;
    bool _moving;

    // Start is called before the first frame update
    void Start()
    {
        _moving = false;
        //Set initial position
        _currentWP = _waypoints.GetNextWP(_currentWP);
        transform.position = _currentWP.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, _currentWP.position, _speed * Time.deltaTime);
            animator.SetFloat("moveX", transform.position.x);
            animator.SetBool("isMoving",true);


        }
    }

    public void Move()
    {
        _moving = true;
    }

    public void NextWP()
    {
        _currentWP = _waypoints.GetNextWP(_currentWP);
        _moving = false;
    }

    public bool ArrivedAtWP()
    {
        return Vector2.Distance(transform.position, _currentWP.position) < _distChange;
    }
}
