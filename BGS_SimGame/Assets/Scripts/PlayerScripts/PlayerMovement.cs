using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 10)]
    public float speed;

    Vector3 dir;
    Animator animController;
    PlayerManager m_player;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponentInChildren<Animator>();
        m_player = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void PlayerInput()
    {
        if (!m_player.IsPlayerMovementAllowed())
        {
            animController.SetBool("isMoving", m_player.IsPlayerMovementAllowed());
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, y);
    }

    void MovePlayer()
    {
        if (!m_player.IsPlayerMovementAllowed())
        {
            animController.SetBool("isMoving", m_player.IsPlayerMovementAllowed());
            return;
        }

        transform.position += Vector3.Normalize(dir) * speed * Time.deltaTime;

        MovementAnimation();
    }

    /// <summary>
    /// Animates player's movement
    /// </summary>
    /// <param name="dir"></param>
    void MovementAnimation()
    {
        if (!animController) return;

        if (dir.magnitude > 0)
        {
            animController.SetBool("isMoving", true);

            animController.SetFloat("horizontal", dir.x);
        }
        else
        {
            animController.SetBool("isMoving", false);
        }
    }
}
