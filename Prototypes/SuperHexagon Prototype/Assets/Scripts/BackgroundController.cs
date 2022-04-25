using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundController : MonoBehaviour
{
    private Camera _camera;
    private Color _backgroundColor;
    private Color _newBackgroundColor;

    private float _colorDuration = 2f;

    private void Start()
    {
        _camera = Camera.main;
        _backgroundColor = _camera.backgroundColor;

        StartCoroutine(ChangeBackgroundColor());
    }

    private IEnumerator ChangeBackgroundColor()
    {
        while (Application.isPlaying)
        {
            _newBackgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            _camera.backgroundColor = Color.Lerp(
                _camera.backgroundColor,
                _newBackgroundColor,
                //Mathf.PingPong(Time.time, _colorDuration)
                 _colorDuration
                );
            yield return new WaitForSeconds(_colorDuration);
        }

        yield return null;
    }
}
