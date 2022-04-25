using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DirectionTests
{
    [Test]
    public void VectorUp()
    {
        Assert.AreEqual(new Vector3(0f,0f,1f), Directions.GetVector(Direction.Up));
    }

    [Test]
    public void VectorDown()
    {
        Assert.AreEqual(new Vector3(0f,0f,-1f), Directions.GetVector(Direction.Down));
    }

    [Test]
    public void VectorLeft()
    {
        Assert.AreEqual(new Vector3(-1f,0f,0f), Directions.GetVector(Direction.Left));
    }

    [Test]
    public void VectorRight()
    {
        Assert.AreEqual(new Vector3(1f,0f,0f), Directions.GetVector(Direction.Right));
    }

    [Test]
    public void DirectionUp()
    {
        Assert.AreEqual(Directions.GetDirection(new Vector3(0f,0f,1f)), Direction.Up);
    }
    
    [Test]
    public void DirectionDown()
    {
        Assert.AreEqual(Directions.GetDirection(new Vector3(0f,0f,-1f)), Direction.Down);
    }
    
    [Test]
    public void DirectionLeft()
    {
        Assert.AreEqual(Directions.GetDirection(new Vector3(-1f,0f,0f)), Direction.Left);
    }
    
    [Test]
    public void DirectionRight()
    {
        Assert.AreEqual(Directions.GetDirection(new Vector3(1f,0f,0f)), Direction.Right);
    }
}
