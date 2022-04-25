using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private List<Block> currentBlocks;
    [SerializeField] private List<Vector2Int> previousPlacements = new List<Vector2Int>();

    private Vector2Int _boardSize = new Vector2Int(7, 20);
    private Vector3 _currentPosition;
    
    private int _blockSize;
    private float _moveSpeed = 2f;
    private float _moveSpeedModifier = 0.5f;
    private bool _rightDirection = true;

    private float _timeToWait;

    private void Start()
    {
        _currentPosition = Vector3.zero;
        _blockSize = 3;
        _timeToWait = 1 / _moveSpeed;

        for (int i = 0; i < _blockSize; i++)
        {
            Block newBlock = Instantiate(
                blockPrefab,
                _currentPosition + (Vector3.right * i),
                Quaternion.identity);
            currentBlocks.Add(newBlock);
        }
    }

    private void Update()
    {
        CheckGameState();
        GetInput();
        Movement();
    }

    private void CheckGameState()
    {
        if (_blockSize <= 0)
        {
            Debug.Log("Game over champ");
            SceneManager.LoadScene(0);
            return;
        }

        if (currentBlocks[0].transform.position.z > 19)
        {
            Debug.Log("You Win Champ!");
        }
    }

    private void CheckDifficulty()
    {
        if (currentBlocks.Count >= 0)
        {
            return;    
        }
        
        if (currentBlocks[0].transform.position.z >= 14f && _blockSize > 1)
        {
            _blockSize = 1;
            _moveSpeedModifier = 2f * _moveSpeedModifier;
            return;
        }
        
        if (currentBlocks[0].transform.position.z >= 10f && _blockSize > 2)
        {
            _blockSize = 2;
            _moveSpeedModifier += 2f;
            return;
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckPlacement();
            CheckDifficulty();
            GetNewBlocks(); 
        }
    }

    private void CheckPlacement()
    {
        if (currentBlocks[0].transform.position.z <= 0)
        {
            foreach (var block in currentBlocks)
            {
                previousPlacements.Add(new Vector2Int(
                    Mathf.RoundToInt(block.transform.position.x),
                    Mathf.RoundToInt(block.transform.position.z)));
            }
            return;
        }

        foreach (var block in currentBlocks)
        {
            if (!previousPlacements.Contains(
                    new Vector2Int(
                        Mathf.RoundToInt(block.transform.position.x),
                        Mathf.RoundToInt(block.transform.position.z) - 1)))
            {
                Destroy(block.gameObject);
                _blockSize--;
            }
            else
            {
                previousPlacements.Add(new Vector2Int(
                    Mathf.RoundToInt(block.transform.position.x),
                    Mathf.RoundToInt(block.transform.position.z)));
            }
        }
    }

    private void GetNewBlocks()
    {
        float zPosition = currentBlocks[0].transform.position.z + 1;
        int xPosition = Random.Range(1, 4);
        
        _rightDirection = (Random.value > 0.5f);
        currentBlocks.Clear();

        for (int i = 0; i < _blockSize; i++)
        {
            Block newBlock = Instantiate(
                blockPrefab,
                new Vector3(xPosition, 0f, zPosition) + (Vector3.right * i),
                Quaternion.identity);
            
            currentBlocks.Add(newBlock);
        }

        _moveSpeed += _moveSpeedModifier;
    }

    private void Movement()
    {
        _timeToWait -= Time.deltaTime;

        if (_timeToWait <= 0f)
        {
            foreach (var block in currentBlocks)
            {
                if (_rightDirection)
                {
                    block.transform.position += Vector3.right;
                }
                else
                {
                    block.transform.position += Vector3.left;
                }
            }

            if (currentBlocks[0].transform.position.x >= _boardSize.x - _blockSize)
            {
                _rightDirection = false;
            }

            if (currentBlocks[0].transform.position.x <= 0)
            {
                _rightDirection = true;
            }

            _timeToWait = 1 / _moveSpeed;
        }
    }
}
