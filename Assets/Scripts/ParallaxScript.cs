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
        _startPosition = transform.position; //ir buscar localização original do background
    }

    private void Update()
    {
        _travel = _camera.transform.position - _startPosition; //variavel para calcular a diferença entra a posição da camara e dos backgrounds para criar movimento
        _parallaxSpeed = (transform.position.z - _player.position.z) / _camera.farClipPlane; //velocidade de cada background é definido pela posição z

        Vector2 newPosition = _startPosition + _travel * _parallaxSpeed;
        transform.position = new Vector3(newPosition.x, _startPosition.y, _startPosition.z); //alterei o valor y para ser constante pois nâo quero que este parallax se mexa na vertical
    }
    
}
