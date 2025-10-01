using UnityEngine;

public class AngryEnemy : Enemy
{
    [SerializeField] private GameObject explosion;
    private void TaoVuNo()
    {
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
    }
    protected override void Chet()
    {
        TaoVuNo();
        base.Chet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null) Chet();
        }
    }
}
