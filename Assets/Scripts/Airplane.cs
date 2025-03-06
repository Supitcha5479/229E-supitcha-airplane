using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f; //thrust f
    [SerializeField] float liftBooster = 0.5f; //lift f
    [SerializeField] float drag = 0.001f; // drag f
    [SerializeField] float angularDrag = 0.001f;

    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;



    void Start()
    {
        GetComponent<Rigidbody>(); 
        
    }

    void FixedUpdate() // update จะเร็วกว่าทุกอย่างเริ่มเท่ากัน แต่ถ้าต้องการให้ฟิสิกเนียนๆ จะใช้อันนี้แทน
    {
        if (Input.GetKey(KeyCode.Space))
        { 
        rb.AddForce(transform.forward* enginePower); //เคลื่อนไปข้างหน้า
        }
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward); 
        rb.AddForce(transform.up * lift.magnitude * liftBooster);
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.angularVelocity.magnitude * angularDrag;


        float yaw = Input.GetAxis("Horizontal") * yawPower;//ซ้ายขวา QE  ในยูนิตี้AD
        float pitch = Input.GetAxis("Vertical") * pitchPower; //จมูกขึ้นลง WS
        float roll = Input.GetAxis("Roll") * rollPower; //หมุน AD ในยูนิตี้QE

        rb.AddTorque(transform.up* yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);
    }
}
