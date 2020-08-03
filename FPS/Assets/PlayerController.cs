 //Le "_" sert a dire que l'on utilise la variable en dehors d'une méthode

using UnityEngine;

//Indication pour Unity (Obligation d'avoir le component "PlayerMotor")
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    //Affiche la prochaine variable dans l'inspecteur 
    [SerializeField]
    private float speed = 5 ; //Pour déplacement

    [SerializeField]
    private float lookSensitivity = 5 ; //Pour rotation

    private PlayerMotor motor ;

    //Fonction lu dès le démarrage
    private void Start()
    {
        //Récupération component PlayerMotor
        motor = GetComponent<PlayerMotor>() ;
    }

    //fonctionne indépendamment du moteur physique, a chaque frame
    private void Update()
    {
        //A quelle vitesse le joueur se déplace et dans quelle direction 
        //Edit -> ProjectSetting -> Input -> Axis (Configuration Axes)
        float _xMov = Input.GetAxisRaw("Horizontal") ; //Vertical = Avancer/Reculer
        /*
            -1 = gauche
             0 = Bouge pas
             1 = droite
        */
        float _zMov = Input.GetAxisRaw("Vertical") ; //Horizontal = Gauche/Droite
        /*
            -1 = recule
             0 = Bouge pas
             1 = avance
        */
        
        Vector3 _moveHorizontal = transform.right * _xMov ; //(0, 0, 0)
        Vector3 _moveVertical = transform.forward * _zMov ; //(0, 0, 0)
                                                            //(x, y, z)
        //Calcul velocité
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed ;
   
        motor.Move(_velocity);


        //Rotation du joueur en un vecteur 3D
        float _yrot = Input.GetAxisRaw("Mouse X") ;
        
        Vector3 _rotation = new Vector3(0, _yrot, 0) * lookSensitivity ;

        motor.Rotate(_rotation) ;

        //Rotation de la camera en un vecteur 3D
        float _xrot = Input.GetAxisRaw("Mouse Y") ;
        
        Vector3 _cameraRotation = new Vector3(_xrot, 0, 0) * lookSensitivity ;

        motor.RotateCamera(_cameraRotation) ;
   }


}
