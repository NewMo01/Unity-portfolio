
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float rotSpeed = 100;
    public float jumpForce = 10;
    private bool isFalling = false;
    public Rigidbody rig;


    // Update is called once per frame
    void Update()
    {
        // rotation horizontal 
        float rotation = Input.GetAxis("Horizontal")* rotSpeed;
        rotation *= Time.deltaTime; 
        rig.AddRelativeTorque(Vector3.back * rotation);

        // jump
        if (Input.GetKeyDown(KeyCode.W) && !isFalling)
        {
            var vel = rig.velocity;
            vel.y = jumpForce;
            rig.velocity = vel;
        }
        isFalling = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        isFalling = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        isFalling = true;
    }

}
