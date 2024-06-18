using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Camera _camera;
    private Vector3 _startPosition;
    private Vector3 _travel;
    private float _parallaxSpeed;

    private void Start()
    {
        _camera = Camera.main;
        _startPosition = transform.position;
    }

    private void Update()
    {
        _travel = _camera.transform.position - _startPosition;
        _parallaxSpeed = (transform.position.z - _player.position.z) / _camera.farClipPlane;

        Vector2 newPosition = _startPosition + _travel * _parallaxSpeed;
        transform.position = new Vector3(newPosition.x, newPosition.y, _startPosition.z);
    }
}
