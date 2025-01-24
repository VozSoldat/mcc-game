using UnityEngine;

public class CombatInput: MonoBehaviour{
    private bool basicAttack = false;
    public bool BasicAttack {get => basicAttack; set => basicAttack = value;}
    private void Update(){
        if (Input.GetButtonDown("Fire1"))
        {
            BasicAttack = true;
        }
        else{
            BasicAttack = false;
        }

        // Debug.Log("Basic Attack: " + BasicAttack);
    }
}