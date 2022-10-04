using UnityEngine;

// Movement types
public enum MoveMode{Normal, Jump, Crawl};

public class Movement
{
    private readonly CharacterController _controller;
    private readonly Transform _transform;
    private const float PlayerSpeed = 5.0f;
    private const float CrawlingSpeed = 2.5f;
    private const float RotationSpeed = 180;
    private const float JumpHeight = 1.0f;
    private const float GravityValue = -9.81f;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private bool _isCrawling;
    private float _currentSpeed;

    public Movement(CharacterController controller, Transform transform)
    {
        _controller = controller;
        _transform = transform;
    }

    // Reset the position.
    public void Reset()
    {
        _controller.enabled = false;
        _transform.localPosition = new Vector3(Random.Range(-8.0f, -6.0f), 0.0f, Random.Range(-7.0f, -3.0f));
        _transform.localRotation = Quaternion.identity;
        _transform.Rotate(0.0f, Random.Range(0.0f, 90.0f), 0.0f, Space.Self);
        _transform.localScale = Vector3.one;
        _currentSpeed = PlayerSpeed;
        _isCrawling = false;
        _controller.enabled = true;
    }

    // Rotate around y-axis
    public void Turn(float input)
    {
        // Clamp input value
        input = Mathf.Clamp(input, -1, 1);
        _transform.Rotate(0.0f, RotationSpeed * Time.deltaTime * input, 0.0f, Space.Self);
    }

    // Move forward/backward
    public void Forward(float input, MoveMode mode)
    {
        // Clamp input value
        input = Mathf.Clamp(input, -1, 1);

        // Check if the player is grounded and set velocity to zero
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer  && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        switch (mode)
        {
            // Standing up.
            case MoveMode.Normal when _isCrawling:
                _transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                _transform.position += new Vector3(0.0f, 0.5f, 0.0f);
                _currentSpeed = PlayerSpeed;
                _isCrawling = false;
                break;
            // Jumping, only if player stands on the ground.
            case MoveMode.Jump when _groundedPlayer && !_isCrawling:
                _playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * GravityValue);
                break;
            // Crawling, only if on the ground and not already crawling.
            case MoveMode.Crawl when !_isCrawling && _groundedPlayer:
                _transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
                _transform.position -= new Vector3(0.0f, 0.5f, 0.0f);
                _currentSpeed = CrawlingSpeed;
                _isCrawling = true;
                break;
        }

        // Apply movement
        var move = _transform.forward * (input + 1.0f) / 2.0f;
        _controller.Move(move * (Time.deltaTime * _currentSpeed));

        // Apply gravity
        _playerVelocity.y += GravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }


}