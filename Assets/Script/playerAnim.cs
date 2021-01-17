using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    private Animator _playerAnim;
    private Animator _swordArck;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponentInChildren<Animator>();
        _swordArck = transform.GetChild(1).GetComponent<Animator>();
    } 

    // Update is called once per frame
    public void Move(float move)
    {
        _playerAnim.SetFloat("Move",Mathf.Abs(move));
    }


    public void jump(bool jumping)
    {
        _playerAnim.SetBool("Jumping", jumping);
    }

    public void attack()
    {
        _playerAnim.SetTrigger("Attack");
        _swordArck.SetTrigger("Sword_arck");

    }
}
