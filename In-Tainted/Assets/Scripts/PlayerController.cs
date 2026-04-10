using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public GameObject weapon;
    public GameObject healObject;
    public Collider weaponCol;

    public int atkIndex = 1;
    private float lastAttackEndTime;

    public float speed = 5f;
    public float defaultSpeed = 5f;
    public float speedMultiplier = 1.5f;

    public float rotationSpeed = 15f;

    public bool canMove = true;
    public bool isAttacking = false;
    public bool isHealing = false;

    public Transform cameraTransform;

    void Start()
    {
        anim = GetComponent<Animator>();
        speed = defaultSpeed;
        anim.SetInteger("AttackIndex", atkIndex);
        weapon.SetActive(true);
    }

    void Update()
    {
        if (canMove)
        {
            Move();
            Sprint();
            HandleHealInput();
        }
        if (!isAttacking)
        {
            CanAttack();
        }
        HandleDodgeInput();
        HandleAttackReset();
    }
    void HandleDodgeInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Dodge");
        }
    }
    void HandleHealInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Heal");
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * moveZ + right * moveX;

        if (move.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        transform.position += move * speed * Time.deltaTime;

        anim.SetBool("isMoving", move.sqrMagnitude > 0.001f);
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = defaultSpeed * speedMultiplier;
            anim.SetBool("Sprinting", true);
        }
        else
        {
            speed = defaultSpeed;
            anim.SetBool("Sprinting", false);
        }
    }
    void CanAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        anim.SetTrigger("Attack");
        isAttacking = true;
    }
    public void OnAttackEnd()
    {
        lastAttackEndTime = Time.time; 
    }

    void HandleAttackReset()
    {
        if (lastAttackEndTime > 0 && Time.time >= lastAttackEndTime + 2.0f)
        {
            atkIndex = 1;
            anim.SetInteger("AttackIndex", atkIndex);
            lastAttackEndTime = 0;
        }
    }
}
