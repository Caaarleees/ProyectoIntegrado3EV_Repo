using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Look Stats")]
    [SerializeField] GameObject camHolder; //Ref al objeto que almacena la cámara
    public float speed;
    public float sprintSpeed;
    public float maxForce; //Limitador de la aceleración del personaje
    public float sensitivity; //Sensibilidad aplicada a la rotación de la cámara
    bool isSprinting;

    //Referencias privadas
    Rigidbody rb;
    Animator animator;
    //Valores de almacenaje de input
    Vector2 moveInput;
    Vector2 lookInput;
    float lookRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        camHolder = GameObject.Find("CameraHolder");
    }

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void FixedUpdate()
    {
        Movement();
    }

    private void LateUpdate()
    {
        CameraLookMove();
    }

    void Movement()
    {
        Vector3 currentVelocity = rb.velocity; //Define la velocidad actual, siempre es igual a la velocidad del Rigidbody
        Vector3 targetVelocity = new Vector3(moveInput.x, 0, moveInput.y); //La velocidad hacia la que nos queremos mover definida por la dirección
        targetVelocity *= speed;

        //Alinear la dirección con la orientación correcta (cámara)
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calcular las fuerzas que afectan al movimiento
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);
        //Limitar la fuerza máxima de aceleración
        velocityChange = Vector3.ClampMagnitude(velocityChange, maxForce);

        //Aplicamos el movimiento en sí mismo
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void CameraLookMove()
    {
        //Girar
        transform.Rotate(Vector3.up * lookInput.x * sensitivity);
        //Mirar
        lookRotation += (-lookInput.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }

    #region Input Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }



    #endregion

}
