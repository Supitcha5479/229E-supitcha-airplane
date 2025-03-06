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

    void FixedUpdate() // update �����ǡ��ҷء���ҧ�������ҡѹ ���ҵ�ͧ��������ԡ��¹� �����ѹ���᷹
    {
        if (Input.GetKey(KeyCode.Space))
        { 
        rb.AddForce(transform.forward* enginePower); //����͹仢�ҧ˹��
        }
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward); 
        rb.AddForce(transform.up * lift.magnitude * liftBooster);
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.angularVelocity.magnitude * angularDrag;


        float yaw = Input.GetAxis("Horizontal") * yawPower;//���¢�� QE  ��ٹԵ��AD
        float pitch = Input.GetAxis("Vertical") * pitchPower; //��١���ŧ WS
        float roll = Input.GetAxis("Roll") * rollPower; //��ع AD ��ٹԵ��QE

        rb.AddTorque(transform.up* yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);
    }
}
