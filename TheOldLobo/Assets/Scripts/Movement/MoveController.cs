using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{

    //Direction handlers
    [SerializeField] private float baseSpeed = 0;

    private DashController _dashController;
    private SprintController _SprintController;
    private Animator ani;
    public Animator animator;

    private Vector2 _input;
    private float varSpeed;
    private bool canMove;

    // Start is called before the first frame update
    private void Start()
    {
        _dashController = GetComponent<DashController>();
        _SprintController = GetComponent<SprintController>();
        ani = GetComponent<Animator>();

        varSpeed = baseSpeed;
        canMove = true;
    }

    // Update is called once per frame

    private void Update()
    {
        //Handle movement mode
        if (_dashController != null && _dashController.IsDashing())
        {
            varSpeed = _dashController.DashPower();
            Sonidos.playSFX("Dash");

        }
        else if (_SprintController != null && _SprintController.IsSprinting())
        {
            varSpeed = _SprintController.Speed();
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
            varSpeed = baseSpeed;
        }
        if (canMove)
        {
            move();
        }
    }

    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void move()
    {
        bool isIdle = _input.x == 0 && _input.y == 0;
        if (isIdle)
        {
            _input = Vector2.zero;
            ani.SetBool("isMoving", false);
        }
        else
        {
            var velocity = _input * varSpeed * Time.deltaTime;
            animator.SetFloat("MoveX", _input.x);
            animator.SetFloat("MoveY", _input.y);
            animator.SetBool("isMoving", true);
            transform.Translate(velocity);
        }
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