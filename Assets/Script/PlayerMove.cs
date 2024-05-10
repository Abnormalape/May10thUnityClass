using UnityEngine;
namespace Demo
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]
        float moveSpeed = 10f;
        [SerializeField]
        float rotationSpeed = 120f;

        Rigidbody rb;
        private void Awake()
        {
            rb= GetComponent<Rigidbody>();
        }
        private void Update()
        {
            float X = Input.GetAxis("Horizontal");
            float Y = Input.GetAxis("Vertical");

            transform.position += transform.forward * moveSpeed * Time.deltaTime * Y;
            transform.rotation *= Quaternion.Euler(0f, X * Time.deltaTime * rotationSpeed, 0f);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, 5f, 0, ForceMode.Impulse);
            }
        }
    }
}