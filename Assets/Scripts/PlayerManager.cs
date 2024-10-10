using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> Prefabs;

    public List<GameObject> Players;
    public int MaxPlayers = 2;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Creates a player character in the game when "Enter" key is pressed. Attached to player Input componet on player manager gameobject.
    public void OnSubmit(InputAction.CallbackContext context) 
    {
        if (Players.Count < MaxPlayers && context.started)
        {
            GameObject player = Instantiate(Prefabs[1], Vector2.zero, Quaternion.identity);
            Players.Add(player);
        }

        
        

        
    }
}

public enum CharacterClass
{
    Ghost,
    Base,
    Special,
    Royal
}
