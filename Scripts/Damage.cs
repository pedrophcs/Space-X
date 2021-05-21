using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;  //  Dano que leva ao contato
    public bool destroyByContact = true;  //  Todos que ser�o destru�dos ao contato do special
    public bool destroyShot = false;  // 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CaracterLife caracter = collision.GetComponent<CaracterLife>();
        if(caracter)
        {
            caracter.TakeDamage(damage);
            if(destroyByContact)  // -------------- Vari�vel bool que tem que ser true em todos os objetos em que o special pode destruir
            Destroy(gameObject);
        }
        Damage shot = collision.GetComponent<Damage>();
        if(shot != null && destroyShot)
        {
            Destroy(collision.gameObject);
        }
    }
}
