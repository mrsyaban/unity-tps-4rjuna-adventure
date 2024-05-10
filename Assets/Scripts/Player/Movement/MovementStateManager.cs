using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float currentMoveSpeed;
    public float walkSpeed = 3, walkBackSpeed = 2;
    [HideInInspector] public float speedUpTime = 0;

    [HideInInspector] public Vector3 dir;
    public float hzInput, vtInput;
    CharacterController controller; 
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;
    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    MovementBaseState currentState;
    public IdleState idle = new IdleState(); 
    public WalkState walk = new WalkState();
    public RunState run = new RunState();

    [HideInInspector] public Animator animator;
    
    private Vector3 previousPosition;
    private float lifetimeTimer;
    private float distanceTraveled;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        if(GameStateManager.Instance.isLoad)
        {
            if(GameStateManager.Instance.hasSpeedOrb)
            {
                this.speedUpTime = GameStateManager.Instance.speedOrbTime;
            }
            transform.position = GameStateManager.Instance.playerPosition;
        }
        previousPosition = transform.position;
        SwitchState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        animator.SetFloat("hzInput", hzInput);
        animator.SetFloat("vtInput", vtInput);

        if(this.speedUpTime == 0)
        {
            this.currentMoveSpeed = 3;
            this.walkSpeed = 3;
            this.walkBackSpeed = 2;
        }
        else
        {
            this.speedUpTime -= 1;
        }
        // distanceTraveled = Vector3.Distance(transform.position, previousPosition);

        previousPosition = transform.position;

        // GameStateManager.Instance.UpdateDistance(distanceTraveled);
        GameStateManager.Instance.UpdatePlayerPosition(transform.position);
        
        lifetimeTimer += Time.deltaTime;
        GameStateManager.Instance.UpdateLifetime(lifetimeTimer);

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove(){
        hzInput = Input.GetAxis("Horizontal");
        vtInput = Input.GetAxis("Vertical");

        dir = transform.forward * vtInput + transform.right * hzInput;

        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void  Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    }
}
