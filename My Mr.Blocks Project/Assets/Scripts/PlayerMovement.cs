using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 2;
    private Rigidbody2D _playerRB;

    private Vector2 _movementInput;

    private bool _levelCompleted;
    void Awake() {
        _playerRB = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_levelCompleted && !Input.GetKey(KeyCode.Space))
        {
            _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            _movementInput = Vector2.zero;
        }
        
    }


    void FixedUpdate() {
        _playerRB.AddForce(_movementInput * moveSpeed * Time.fixedDeltaTime,ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.tag == "Actual Door" && !_levelCompleted)
        {
            Debug.Log("Level Completed!!");
            _levelCompleted = true;
        }    
    }
}
