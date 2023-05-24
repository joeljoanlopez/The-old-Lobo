using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{

    //Direction handlers
    [SerializeField] private float baseSpeed = 0;

    private DashController _dashController;
    private SprintController _SprintController;
    private Animator idle;
    public Animator animator;

    private Vector2 _input;
    private float varSpeed;
    private bool canMove;

    // Start is called before the first frame update
    private void Start()
    {
        _dashController = GetComponent<DashController>();
        _SprintController = GetComponent<SprintController>();
        idle = GetComponent<Animator>();

        varSpeed = baseSpeed;
        canMove = true;
    }

    // Update is called once per frame

    private void Update()
    {
        //Handle movement mode
        if (_dashController.IsDashing()) 
            varSpeed = _dashController.DashPower();
        else if (_SprintController.IsSprinting()) 
            varSpeed = _SprintController.Speed();
        else 
            varSpeed = baseSpeed;

        if (canMove)
            move();

        if (_input != Vector2.zero)
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);
        else
            idle.SetFloat("moving", idle.GetFloat("moving") - idle.GetFloat("moving"));
    }

    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void move()
    {
        var velocity = _input * varSpeed * Time.deltaTime;
        animator.SetFloat("horizontal", _input.x);
        animator.SetFloat("vertical", _input.y);
        animator.SetFloat("moving", _input.sqrMagnitude);
        transform.Translate(velocity);
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void ResumeMovement()
    {
        canMove = true;
    }
}