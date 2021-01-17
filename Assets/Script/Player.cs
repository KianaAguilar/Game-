using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private bool _grounded = false;
    private bool _resetJumNided = false;
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private playerAnim _playerAnim;

    private SpriteRenderer _playerSprite;
    //private SpriteRenderer _swordArckSprite; 

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<playerAnim>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
       //  _swordArckSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetMouseButtonDown(0) && _grounded == true)
        {
            _playerAnim.attack();
        }
    }

    void Movement()
    {

        float move = Input.GetAxisRaw("Horizontal");
       

        if (move > 0)
        {
            flip(true);
        }
        else if (move < 0)
        {
            flip(false);
        }

         if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            _resetJumNided = true;
            StartCoroutine(ResetJumpRutine());
            _playerAnim.jump(true);
            
        }

        
          _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
          _playerAnim.Move(move);
          IsGrounded();
    }

    void flip(bool faceRigth)
    {
        if (faceRigth == true)
        {
           _playerSprite.flipX = false;

          /*  _swordArckSprite.flipX = false;
            _swordArckSprite.flipY = false;
            Vector3 newPoss = _swordArckSprite.transform.localPosition;
            newPoss.x = 1.01f;
            _swordArckSprite.transform.localPosition = newPoss;*/
        }
        else if (faceRigth == false)
        {
            _playerSprite.flipX = true;
         /*   _swordArckSprite.flipX = true;
            _swordArckSprite.flipY = true;
            Vector3 newPoss = _swordArckSprite.transform.localPosition;
            newPoss.x = -1.01f;
            _swordArckSprite.transform.localPosition = newPoss;*/
        }
    }

    void IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.5f , 1 << 8);
        if (hitInfo.collider != null)
        {
            if (_resetJumNided == false)
            {
                _playerAnim.jump(false);
                _grounded = true;
            }
           
        }
    }

    IEnumerator ResetJumpRutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJumNided = false;
    }
}

