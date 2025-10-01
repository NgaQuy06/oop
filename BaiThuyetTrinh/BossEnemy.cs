using System.Collections;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject vatPham;
    private Animator anim;
    protected override void Start()
    {
        base.Start();
        gameObject.SetActive(true);
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Chet()
    {
        base.Chet();
        RoiVatPham();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null) player.MatMau(satThuong);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null) player.MatMau(doTreGaySatThuong);
        }
    }
    private void RoiVatPham()
    {
        if (vatPham != null && mauHienTai <= 0)
        {
            GameObject vp = Instantiate(vatPham, transform.position, Quaternion.identity);
            Destroy(vp, 10);
        }
    }
}
