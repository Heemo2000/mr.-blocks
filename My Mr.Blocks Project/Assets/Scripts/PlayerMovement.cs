using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 2;
    [SerializeField]private LevelUI levelUI;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            levelUI.PauseGame();
        }
        
        
        if(!levelUI.IsGamePaused && !_levelCompleted && !Input.GetKey(KeyCode.Space))
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
        if(!_levelCompleted)
        {
            _levelCompleted = true;
            if(other.tag == "Actual Door")
            {
                levelUI.ShowResult(true);
            }
            else if(other.tag == "Fake Door")
            {
                levelUI.ShowResult(false);
            }    
        }
            
    }
}
