using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{    
    public int Health = 1;
    public float MoveSpeed = 10f;
    private Vector2 moveVelocity;

    public float JumpForce = 15f;
    public bool isGrounded;
    public Rigidbody2D RB;
    public Transform GroundCheckPoint;
    public LayerMask GroundLayer; 

    
    public CharacterClass cClass;
    public GameObject[] Characters;
    public GameObject currentCharacter;

    public CapsuleCollider2D col;
    public PlayerInput playerInput;
        
    void Awake()
    {
        if (col == null)
        {
            Debug.Log(col);
            col = GetComponent<CapsuleCollider2D>();
        }

        
        playerInput = GetComponent<PlayerInput>();
        //Debug.Log(playerInput.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(GroundCheckPoint.position, Vector2.one * 0.5f, 0f, GroundLayer);

        RB.velocity = new Vector2(moveVelocity.x * MoveSpeed, RB.velocity.y); //TODO:Fix ghost  up/down movement, assigning y velocity to itself, value not coming from player input
    }

    //Get left/right input from the input actions
    public void Move(InputAction.CallbackContext context)        
    {
        moveVelocity = context.ReadValue<Vector2>();
        //moveVelocity = context.ReadValue<Vector2>().x;
    }

    //get the jump input and apply to the rigidbody
    public void Jump(InputAction.CallbackContext context)
    {
        if (RB != null && isGrounded) 
        {
            RB.velocity += Vector2.up * JumpForce;
        }
        
    }
    //used when a player is hit and takes damage. 
    public void TakeHit(int dmg)
    {
        Health -= dmg;

        //check if player has died
        if (Health <= 0)
        {
            Die();
        }
    }
    
    
    //Spawns the charcter 
    void Spawn()
    {
        cClass = CharacterClass.Base;
        CharacterSwap();
    }
    //Transforms the character into a ghost
    void Die()
    {
        Debug.Log("Player Dies)");
        cClass = CharacterClass.Ghost;
        CharacterSwap();
    }

    //Upgrades the character
    void Upgrade()
    {
        if (cClass == CharacterClass.Base)
        {
            cClass = CharacterClass.Special;
            CharacterSwap();
            
        }else if (cClass == CharacterClass.Special)
        {
            cClass = CharacterClass.Royal;
            CharacterSwap();
        }
    }

    //Swaps the character prefabs when a player transforms 
    void CharacterSwap()
    {
        Debug.Log("CharacterSwap");

        GameObject oldCharater = currentCharacter;

        switch (cClass)
        {
            case CharacterClass.Ghost:
                SetUpGhost();
                break;
            case CharacterClass.Base:
                SetupBase();
                break;
        }

        currentCharacter.transform.SetParent(this.transform);
        currentCharacter.transform.localPosition = Vector2.zero;

        Destroy(oldCharater);
    }

    void SetUpGhost()
    {
        currentCharacter = Instantiate(Characters[0]);
        RB.gravityScale = 0; // gravity = 0
        col.isTrigger = true;// disable collisions
        playerInput.SwitchCurrentActionMap("Ghost"); //change action map?  
        MoveSpeed = 3f;// move speed = 3
        JumpForce = 0f;
        // trigger spawn animation
    }

    void SetupBase()
    {
        currentCharacter = Instantiate(Characters[1]);
        RB.gravityScale = 9.8f;// gravity = 9.8
        col.isTrigger = false;// enable collisions
        playerInput.SwitchCurrentActionMap("Base"); // change action map?
        MoveSpeed = 10f;// move speed = 10
        JumpForce = 15f;
        // trigger spawn animation
    }


}
