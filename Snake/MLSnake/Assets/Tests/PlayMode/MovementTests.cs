using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MovementTests
{
    /// <summary>
    /// Tests to ensure player movement is as expected
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator MovementUp()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var snake = Object.FindObjectOfType<Snake>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Up);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        var position = snake.Head.transform.localPosition;

        Assert.AreEqual(0, position.x);
        Assert.AreEqual(0, position.y);
        Assert.IsTrue(position.z > 0f);
    }
    
    [UnityTest]
    public IEnumerator MovementDown()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var snake = Object.FindObjectOfType<Snake>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Down);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        var position = snake.Head.transform.localPosition;

        Assert.AreEqual(0, position.x);
        Assert.AreEqual(0, position.y);
        Assert.IsTrue(position.z < 0f);
    }
    
    [UnityTest]
    public IEnumerator MovementLeft()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var snake = Object.FindObjectOfType<Snake>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Left);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        var position = snake.Head.transform.localPosition;

        Assert.AreEqual(0, position.z);
        Assert.AreEqual(0, position.y);
        Assert.IsTrue(position.x < 0f);
    }
    
    [UnityTest]
    public IEnumerator MovementRight()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var snake = Object.FindObjectOfType<Snake>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Right);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        var position = snake.Head.transform.localPosition;

        Assert.AreEqual(0, position.z);
        Assert.AreEqual(0, position.y);
        Assert.IsTrue(position.x > 0f);
    }

    [UnityTest]
    public IEnumerator MovementUpThenDown()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var playerController = Object.FindObjectOfType<PlayerController>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Up);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        movementVector = Directions.GetVector(Direction.Down);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);
        
        Assert.AreEqual(Direction.Up, playerController.Direction);
    }
    
    [UnityTest]
    public IEnumerator MovementDownThenUp()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var playerController = Object.FindObjectOfType<PlayerController>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Down);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        movementVector = Directions.GetVector(Direction.Up);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);
        
        Assert.AreEqual(Direction.Down, playerController.Direction);
    }

    [UnityTest]
    public IEnumerator MovementLeftThenRight()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var playerController = Object.FindObjectOfType<PlayerController>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Left);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        movementVector = Directions.GetVector(Direction.Right);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);
        
        Assert.AreEqual(Direction.Left, playerController.Direction);
    }
    
    [UnityTest]
    public IEnumerator MovementRightThenLeft()
    {
        SceneManager.LoadScene(0);
        yield return null;

        var environmentEvents = Object.FindObjectOfType<EnvironmentEvents>();
        var playerController = Object.FindObjectOfType<PlayerController>();

        yield return new WaitForSeconds(.5f);

        var movementVector = Directions.GetVector(Direction.Right);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);

        movementVector = Directions.GetVector(Direction.Left);
        environmentEvents.Input(movementVector);
        
        yield return new WaitForSeconds(.3f);
        
        Assert.AreEqual(Direction.Right, playerController.Direction);
    }
}
