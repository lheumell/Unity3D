
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam ;
    private bool isFPS = false ;
    



    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 rotationCamera;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation ; //Supprime contraintes de rb(ne peut plus rouler)
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity ;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation ;
    }

    public void RotateCamera(Vector3 _rotationCamera)
    {
        rotationCamera = _rotationCamera ;
    }

    //FixedUpdate est utilisé pour être en phase avec le moteur physique,
    //donc tout ce qui doit être appliqué à un corps rigide devrait se produire dans FixedUpdate
    private void FixedUpdate()
    {
        PerformMovement() ;
        PerformRotation() ;
        Gravity() ;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isFPS)
            {
                isFPS = false;
                //   cam.transform.position = new Vector3(cam.transform.position.x,cam.transform.position.y, cam.transform.position.z -4);
                Vector3.Lerp(transform.position, rb.transform.position *3, 1);
            }
            else
            {
                isFPS = true; 
                cam.transform.position = transform.position ;
            }
        }
    }

    private void PerformMovement()
    {
        if(velocity != Vector3.zero){
            //Deplace rb(joueur) a la position actuelle de rb + la velocité en se basant sur le temps  
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-rotationCamera);
    }

    private void Gravity(){
        
        Vector3 position = transform.position ;
    
        if(Input.GetKey(KeyCode.Space)){
            if(position.y < -9){
                rb.AddForce(0,25,0) ;
            }
            rb.AddForce(0,15,0) ;
        }
    }

}
