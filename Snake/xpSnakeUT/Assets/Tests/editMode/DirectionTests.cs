using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class DirectionTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void North()
    {
        Assert.AreEqual(new Vector3(0,0, 1), Vector3.forward);
    }
    [Test]
    public void South()
    {
        Assert.AreEqual(new Vector3(0,0, -1), Vector3.back);
    }
    [Test]
    public void West()
    {
        Assert.AreEqual(new Vector3(-1,0, 0), Vector3.left);
    }
    [Test]
    public void East()
    {
        Assert.AreEqual(new Vector3(1,0, 0), Vector3.right);
    }
}
