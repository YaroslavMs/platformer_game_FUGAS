using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemy_behaviour : MonoBehaviour
{
    public GameObject leftMax;
    public GameObject rightMax;
    public GameObject viewTrigger;
    public GameObject attackChecker;
    public BoxCollider2D box1;
    public BoxCollider2D box2;

    private enum States
    {
        Wandering,
        Run,
        Death
    }

    private States _currentState;
    private bool _facingRight = true;
    private float _savedTime;
    private float _invincibilityTime;
    private float _deathTime;
    private float _speed;
    private Animator _animator;
    private Transform _playerTransform;
    private int _hp = 2;

    private void Start()
    {
        gameObject.SetActive(true);
        _animator = GetComponent<Animator>();
        _currentState = States.Wandering;
        viewTrigger.GetComponent<TriggerView>().PlayerEntered += CheckPlayer;
        attackChecker.GetComponent<CheckForAttack>().AttackPerforming += Attack;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Attack") && Time.time - _invincibilityTime > 0.4)
        {
            _invincibilityTime = Time.time;
            _hp -= 2;
        }
    }

    private void CheckPlayer(bool x, Transform player)
    {
        _playerTransform = player;
        if (x)
        {
            _currentState = States.Run;
        }

        if (!x)
        {
            _currentState = States.Wandering;
            _animator.SetBool("running", false);
        }
    }


    private void Update()
    {
        if (_hp <= 0)
        {
            box1.enabled = false;
            box2.enabled = false;
            attackChecker.SetActive(false);
            viewTrigger.SetActive(false);
            _currentState = States.Death;
            _animator.SetTrigger("Death");
            _deathTime = Time.time;
            _hp = 1000;
        }

        switch (_currentState)
        {
            case States.Wandering:
                Wander();
                break;
            case States.Run:
                Run();
                break;
            case States.Death:
                if (Time.time - _deathTime > 1)
                {
                    gameObject.SetActive(false);
                }

                break;
        }
    }

    private void Flip(bool x)
    {
        if (_facingRight != x)
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        _facingRight = x;
    }

    private void Wander()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if (Time.time - _savedTime > 2 || _savedTime == 0)
        {
            _savedTime = Time.time;
            var rand = Random.Range(0.0f, 1.0f);
            if (rand > 0.75f)
            {
                _speed = 1;
                Flip(true);
            }
            else if (rand > 0.5f)
            {
                _speed = -1;
                Flip(false);
            }
            else
            {
                _speed = 0;
            }
        }
        else if (transform.position.x > rightMax.transform.position.x)
        {
            _speed = -1;
            Flip(false);
        }
        else if (transform.position.x < leftMax.transform.position.x)
        {
            _speed = 1;
            Flip(true);
        }

        _animator.SetInteger("speed", (int) _speed);
    }

    private void Run()
    {
        if (transform.position.x > _playerTransform.position.x)
        {
            _speed = -1.5f;
            Flip(false);
            if (transform.position.x <= leftMax.transform.position.x)
            {
                _speed = 0;
            }
        }
        else if (transform.position.x < _playerTransform.position.x)
        {
            _speed = 1.5f;
            Flip(true);
            if (transform.position.x >= rightMax.transform.position.x)
            {
                _speed = 0;
            }
        }

        _animator.SetInteger("speed", (int) _speed);

        if (_speed == 0)
        {
            _animator.SetBool("running", false);
        }
        else
        {
            _animator.SetBool("running", true);
        }

        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void Attack(bool at)
    {
        _animator.SetBool("attack", at);
    }
}