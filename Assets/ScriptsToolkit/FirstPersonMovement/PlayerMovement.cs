using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private Vector3 velocity;  //存储当前速度
    [Header("地面检测点")]
    public Transform groundCheck;
    [Header("检测球半径")]
    public float groundDistance = 0.4f;
    [Header("地面所在的Layer(用于过滤检测对象)")]
    public LayerMask groundMask;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  //一个经验：设置成一个较小负数会比设置成0得到的效果更好
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)   //"Jump"会自动映射到空格键
        {
            velocity.y = Mathf.Sqrt(-2f * gravity * jumpHeight); //物理公式
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
