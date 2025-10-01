using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float tocDoBayVienDan = 25f;
    [SerializeField] protected float thoiGianTonTaiDan = 0.5f;
    [SerializeField] protected float satThuong = 10f;
    protected void Start()
    {
        Destroy(gameObject, thoiGianTonTaiDan);
    }
    protected void Update()
    {
        DiChuyenVienDan();
    }
    protected void DiChuyenVienDan()
    {
        transform.Translate(Vector2.right * tocDoBayVienDan * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) enemy.MatMau(satThuong);
            Destroy(gameObject);
        }
    }
}
