using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    private const float Speed = 50;
    private const float MovingSpeed = 1f;
    private const float MovingRange = 2f;

    private Vector3 _movingDirection = Vector3.forward;
    private float _random1;
    private float _random2;
    private float _random3;

    void Start()
    {
        Initial();
    }

    void Update()
    {
        var position = transform.position;
        if (_movingDirection == Vector3.forward && position.z > MovingRange)
        {
            _movingDirection = Vector3.back;
        }
        else if (_movingDirection == Vector3.back && position.z < -MovingRange)
        {
            _movingDirection = Vector3.forward;
        }
        transform.Translate(_movingDirection * (MovingSpeed * Time.deltaTime), Space.World);
        transform.Rotate(new Vector3(_random1, _random2, _random3) * (Speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Initial();
        }
    }

    private void Initial()
    {
        _random1 = Random.Range(0f, 1f);
        _random2 = Random.Range(0f, 1f);
        _random3 = Random.Range(0f, 1f);

        var material = meshRenderer.material;
        material.color = new Color(_random1, _random2, _random3, Random.Range(0.2f, 0.8f));
    }
}