using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ---------------------------------------------------- SCRIPT PARA COLIDIR COM OS POWER UPS E DESTRUÍ-LOS
public class ItemDrop : MonoBehaviour
{
    public ItemEffect effect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            player.SetItemEffect(effect);
            Destroy(gameObject);
        }
    }
}
