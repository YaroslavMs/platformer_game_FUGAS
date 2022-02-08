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

    private enum States
    {
        Wandering,
        Run,
    }

    private States _currentState;
    private bool _facingRight = true;
    private float _savedTime;
    private float _speed;
    private Animator _animator;
    private Transform _playerTransform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentState = States.Wandering;
        viewTrigger.GetComponent<TriggerView>().PlayerEntered += CheckPlayer;
        attackChecker.GetComponent<CheckForAttack>().AttackPerforming += Attack;
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
        switch (_currentState)
        {
            case States.Wandering:
                Wander();
                break;
            case States.Run:
                Run();
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
            if (rand > 0.8f)
            {
                _speed = 1;
                Flip(true);
            }
            else if (rand > 0.6f)
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