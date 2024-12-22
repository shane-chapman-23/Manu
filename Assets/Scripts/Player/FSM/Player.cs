using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerFSMController StateMachineController { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerSlideState SlideState { get; private set; }

    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Anim { get; private set; }
    public InputHandler InputHandler { get; private set; }

    [SerializeField] private PlayerData _playerData;

    public int XInput { get; private set; }
    public int FacingDirection { get; private set; } = 1;

    private Vector2 _workSpace;
    private Vector2 _currentVelocity;

    private void Awake()
    {
        Instance = this;

        StateMachineController = new PlayerFSMController();

        IdleState = new PlayerIdleState(this, StateMachineController, _playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachineController, _playerData, "move");
        SlideState = new PlayerSlideState(this, StateMachineController, _playerData, "slide");

        Rigidbody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<InputHandler>();
    }

    private void Start()
    {
        StateMachineController.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachineController.CurrentState.LogicUpdate();

        XInput = InputHandler.NormInputX;
    }

    private void FixedUpdate()
    {
        StateMachineController.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        _workSpace.Set(velocity, _currentVelocity.y);
        Rigidbody.linearVelocity = _workSpace;
        _currentVelocity = _workSpace;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }


}
