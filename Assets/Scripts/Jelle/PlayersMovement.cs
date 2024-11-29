using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersMovement : MonoBehaviour
{
    private Rigidbody Player1RigidBody;
    private Rigidbody Player2RigidBody;

    private Vector2 MovementInputsVector2Player1;
    private Vector2 MovementInputsVector2Player2;

    [Header("Movement settings")]
    [SerializeField] private float MovementSpeed;

    [Header("Movement inputs")]
    [SerializeField] private InputAction MovementInputsPlayer1;
    [SerializeField] private InputAction MovementInputsPlayer2;

    [Header("Player gameobjects")]
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;

    private void OnEnable()
    {
        MovementInputsPlayer1.Enable();
        MovementInputsPlayer2.Enable();
    }

    private void OnDisable()
    {
        MovementInputsPlayer1.Disable();
        MovementInputsPlayer2.Disable();
    }

    private void Start()
    {
        Player1RigidBody = Player1.GetComponent<Rigidbody>();
        Player2RigidBody = Player2.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckInput();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CheckInput()
    {
        MovementInputsVector2Player1 = MovementInputsPlayer1.ReadValue<Vector2>().normalized;
        MovementInputsVector2Player2 = MovementInputsPlayer2.ReadValue<Vector2>().normalized;
    }

    private void Movement()
    {
        Player1RigidBody.linearVelocity = new Vector3(MovementInputsVector2Player1.x * MovementSpeed, 0, MovementInputsVector2Player1.y * MovementSpeed);
        Player2RigidBody.linearVelocity = new Vector3(MovementInputsVector2Player2.x * MovementSpeed, 0, MovementInputsVector2Player2.y * MovementSpeed);
    }

    private void RotatePlayer()
    {
        if (MovementInputsVector2Player1[0] == 1 && MovementInputsVector2Player1[1] == 0)
        {
            Player1.transform.rotation = Quaternion.Slerp(Player1.transform.rotation, Quaternion.Euler(0, 270, 0), 0.15f);
        }
        else if(MovementInputsVector2Player1[0] == -1 && MovementInputsVector2Player1[1] == 0)
        {
            Player1.transform.rotation = Quaternion.Slerp(Player1.transform.rotation, Quaternion.Euler(0, 90, 0), 0.15f);
        }
        else if (MovementInputsVector2Player1[1] == 1 && MovementInputsVector2Player1[0] == 0)
        {
            Player1.transform.rotation = Quaternion.Slerp(Player1.transform.rotation, Quaternion.Euler(0, 180, 0), 0.15f);
        }
        else if (MovementInputsVector2Player1[1] == -1 && MovementInputsVector2Player1[0] == 0)
        {
            Player1.transform.rotation = Quaternion.Slerp(Player1.transform.rotation, Quaternion.Euler(0, 360, 0), 0.15f);
        }

        if (MovementInputsVector2Player2[0] == 1 && MovementInputsVector2Player2[1] == 0)
        {
            Player2.transform.rotation = Quaternion.Slerp(Player2.transform.rotation, Quaternion.Euler(0, 270, 0), 0.15f);
        }
        else if (MovementInputsVector2Player2[0] == -1 && MovementInputsVector2Player2[1] == 0)
        {
            Player2.transform.rotation = Quaternion.Slerp(Player2.transform.rotation, Quaternion.Euler(0, 90, 0), 0.15f);
        }
        else if (MovementInputsVector2Player2[1] == 1 && MovementInputsVector2Player2[0] == 0)
        {
            Player2.transform.rotation = Quaternion.Slerp(Player2.transform.rotation, Quaternion.Euler(0, 180, 0), 0.15f);
        }
        else if (MovementInputsVector2Player2[1] == -1 && MovementInputsVector2Player2[0] == 0)
        {
            Player2.transform.rotation = Quaternion.Slerp(Player2.transform.rotation, Quaternion.Euler(0, 360, 0), 0.15f);
        }
    }
}
