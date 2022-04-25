using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Bean bean;
    [SerializeField] private List<GameObject> snake;
    [SerializeField] private GameObject tailPrefab;

    private GameObject _head;
    private GameObject _tail;
    private int lastPart;
    
    private Rigidbody _rb;
    private Direction _moveDirection;
    private Vector3 _startPosition;
    private float _startMoveSpeed;
    private float _timeToWait; // more choppy movement, snake style

    public event Action GameReset;
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        GameReset?.Invoke();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _moveDirection = Direction.Up;
        _startPosition = transform.position;
        _startMoveSpeed = moveSpeed;
        _timeToWait = 1 / moveSpeed;
    }

    private void Start()
    {
        bean.BeanPickedUp += BeanPickedUpHandler;
        
        _head = snake[0];
        lastPart = snake.Count - 1;
        _tail = snake[lastPart];
    }

    private void Update()
    {
        GetInput();
        CheckDirection();           
    }

    private void OnDestroy()
    {
        bean.BeanPickedUp -= BeanPickedUpHandler;
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) && _moveDirection != Direction.Down)
        {
            _moveDirection = Direction.Up;
            return;
        }
        
        if (Input.GetKey(KeyCode.DownArrow) && _moveDirection != Direction.Up)
        {
            _moveDirection = Direction.Down;
            return;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && _moveDirection != Direction.Right)
        {
            _moveDirection = Direction.Left;
            return;
        }
        
        if (Input.GetKey(KeyCode.RightArrow) && _moveDirection != Direction.Left)
        {
            _moveDirection = Direction.Right;
            return;
        }
    }

    private void CheckDirection()
    {
        switch (_moveDirection)
        {
            case Direction.Up:
                Movement(Vector3.forward);
                break;
            case Direction.Down:
                Movement(Vector3.back);
                break;
            case Direction.Left:
                Movement(Vector3.left);
                break;
            case Direction.Right:
                Movement(Vector3.right);
                break;
        }
    }

    private void Movement(Vector3 direction)
    {
        _timeToWait -= Time.deltaTime;
        
        if (_timeToWait <= 0f)
        {
            _tail.transform.position = _head.transform.position + direction;
            _head = _tail;
            
            lastPart--;
            if (lastPart < 0) lastPart = snake.Count - 1;
            _tail = snake[lastPart];
            
            _timeToWait = 1 / moveSpeed;
        }
    }

    private void BeanPickedUpHandler()
    {
        moveSpeed += 1f;
        GameObject newPart = Instantiate(tailPrefab, new Vector3(100f, 0f, 0f), Quaternion.identity);
        snake.Add(newPart);
        _tail = newPart;
        lastPart++;
    }
}
