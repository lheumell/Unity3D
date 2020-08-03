//Le script est attaché au personnage

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor ;
    private Transform _body ; 
    private Rigidbody rb ;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
         rb.useGravity = false ; //Supprime gravité de rb
         rb.constraints = RigidbodyConstraints.FreezeRotation ; //Supprime contraintes de rb(ne peut plus rouler)
         _body = transform ; //permet de stocker dans la variable _body notre personnage(position,rotation,scale)
    }
   
    void FixedUpdate()
    {
        
        if(attractor){
            attractor.Attract(_body) ; //Fonction qui va permettre d'attirer l'objet qui possede le script GravityBody
        }

        Gravity() ;
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
