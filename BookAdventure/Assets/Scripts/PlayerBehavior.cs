using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerBehavior : MonoBehaviour
{
    // 1
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;
    public float JumpVelocity = 5f;
    private bool _isJumping;
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public GameObject Bullet;
    public float BulletSpeed = 100f;

    private bool _isShooting;
    private GameBehavior _gameManager;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //3
        _rb = GetComponent<Rigidbody>();

        _col = GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find ("Game Manager").GetComponent<GameBehavior>();

    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        
        /*
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */
        // i believe this is rotation using code. disabled since we're doing it using unity's animation

        _isJumping |= Input.GetKeyDown(KeyCode.J);
    
        _isShooting |= Input.GetKeyDown(KeyCode.Space);

    }

    // 1
    void FixedUpdate()
    {

// movement
        // 2
        Vector3 rotation = Vector3.up * _hInput;
        // 3
        Quaternion angleRot = Quaternion.Euler(rotation *
        Time.fixedDeltaTime);
        // 4
        _rb.MovePosition(this.transform.position +
        this.transform.forward * _vInput * Time.fixedDeltaTime);
        // 5
        _rb.MoveRotation(_rb.rotation * angleRot);

// jumping code
        
        /*
        if(_isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        */

        
        if(IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity,
                ForceMode.Impulse);
        }

        _isJumping = false;



//shooting code
        if (_isShooting)
            {
                // 5
                GameObject newBullet = Instantiate(Bullet,
                this.transform.position + new Vector3(0, 0, 1),
                this.transform.rotation);
                // 6
                Rigidbody BulletRB =
                newBullet.GetComponent<Rigidbody>();
                // 7
                BulletRB.linearVelocity = this.transform.forward *
                BulletSpeed;
            }

        _isShooting = false;
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);

        return grounded;

    }
    // code for ensuring you can't jump in the air, but i'm pretty sure you can still jump in the air.

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }


    }



}
