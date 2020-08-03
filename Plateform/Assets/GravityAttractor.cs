//Le script est attaché a la planete

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
   public float gravity = -12 ;

   public void Attract(Transform body)
   {
       Vector3 gravityUp = (body.position - transform.position).normalized ; //On fait la différence entre le vecteur(position) du personnage et celui de la planete
       Vector3 localUp = body.up ;//Fait tourner l'objet(personnage) sur l'axe Y

       body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity) ; // Objet sur lequel je veux appliquer ma force.GetComponent<Rigidbody>().AddForce(vecteur3) ;
   
        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation ;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime) ;
   }
}
