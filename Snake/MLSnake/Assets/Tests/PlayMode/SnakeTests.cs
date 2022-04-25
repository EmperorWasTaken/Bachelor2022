using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SnakeTests
{
    /// <summary>
    /// Unit tests for the snake initialization and its property values.
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator SnakeInitHead()
    {
        SceneManager.LoadScene(0);
        yield return null;
        
        var snake = Object.FindObjectOfType<Snake>();
        yield return new WaitForSeconds(.5f);
        
        snake.InitSnake();
        
        Assert.AreEqual(snake.Head, snake.SnakeBody[0]);
    }

    [UnityTest]
    public IEnumerator SnakeInitTail()
    {
        SceneManager.LoadScene(0);
        yield return null;
        
        var snake = Object.FindObjectOfType<Snake>();
        yield return new WaitForSeconds(.5f);
        
        snake.InitSnake();
        
        Assert.AreEqual(snake.Tail, snake.SnakeBody[0]);
    }

    [UnityTest]
    public IEnumerator SnakeInitSize()
    {
        SceneManager.LoadScene(0);
        yield return null;
        
        var snake = Object.FindObjectOfType<Snake>();
        yield return new WaitForSeconds(.5f);
        
        snake.InitSnake();
        
        Assert.AreEqual(1, snake.SnakeSize);
    }

    [UnityTest]
    public IEnumerator SnakeInitTailIndex()
    {
        SceneManager.LoadScene(0);
        yield return null;
        
        var snake = Object.FindObjectOfType<Snake>();
        yield return new WaitForSeconds(.5f);
        
        snake.InitSnake();
        
        Assert.AreEqual(0, snake.TailIndex);
    }

    [UnityTest]
    public IEnumerator SnakeThreeBeanSize()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var snake = Object.FindObjectOfType<Snake>();
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < 3; i++)
        {
            environmentEvents.BeanPickedUp();
        }
        
        Assert.AreEqual(4, snake.SnakeSize);
    }
    
    [UnityTest]
    public IEnumerator SnakeThreeBeanCountActiveInSnakeBody()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var snake = Object.FindObjectOfType<Snake>();
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < 3; i++)
        {
            environmentEvents.BeanPickedUp();
        }

        int count = 0;
        
        foreach (var part in snake.SnakeBody)
        {
            if (part.activeInHierarchy)
            {
                count++;
            }
        }
        
        Assert.AreEqual(4, count);
    }
}
