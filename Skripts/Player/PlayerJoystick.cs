using UnityEngine;

//  player control

public class PlayerJoystick : MonoBehaviour
{

    public float speed = 1;
    public Joystick joystickFly;      // joystick prefab. according to the principle of free location

    void FixedUpdate()
    {
        //  give the object speed in the direction of the joystick
        GetComponent<Rigidbody>().velocity = new Vector3(joystickFly.Horizontal * speed, 0, joystickFly.Vertical * speed);

        //  if the joystick is not at zero
        if ((joystickFly.Horizontal != 0 || joystickFly.Vertical != 0))
          {
            //  rotation of the object in the direction of motion
            transform.rotation = Quaternion.LookRotation(this.GetComponent<Rigidbody>().velocity);

              this.GetComponent<Animator>().SetBool("run", true);
          }
          else this.GetComponent<Animator>().SetBool("run", false);
    }
}
