using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float movement_speed = 1;
    public float jump_force = 1;
    public Animator animator;

    private Rigidbody2D rigid_body;

    private void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Для перемещения персонажа.
        var move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * movement_speed;

        animator.SetFloat("Speed", Mathf.Abs(move * movement_speed));

        // Для прыжка персонажа.
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigid_body.velocity.y) < 0.001f)
        {
            rigid_body.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }

        if (Mathf.Abs(rigid_body.velocity.y) < 0.001f)
        {
            animator.SetBool("IsJumping", false);
        }

        // Для поворота персонажа.
        Vector3 character_scale = transform.localScale;

        character_scale.x = Input.GetAxis("Horizontal") < 0 ?  -1 : 1;

        transform.localScale = character_scale;
    }
}
