using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float tocDoDiChuyen = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private float mauToiDa = 100f;
    protected float mauHienTai;
    [SerializeField] private Image thanhMau;
    [SerializeField] private Manager manager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        mauHienTai = mauToiDa;
    }
    void Update()
    {
        if (manager.IsGameWin() || manager.IsGameOver()) return;
        DiChuyen();
        CapNhatThanhMau();
    }
    private void DiChuyen()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = playerInput.normalized * tocDoDiChuyen;
        if (playerInput.x < 0) sr.flipX = true;
        else if (playerInput.x > 0) sr.flipX = false;
    }
    public void MatMau(float satThuong)
    {
        mauHienTai -= satThuong;
        mauHienTai = Mathf.Max(mauHienTai, 0);
        CapNhatThanhMau();
        if (mauHienTai <= 0) Chet();
    }
    private void Chet()
    {
        Destroy(gameObject);
        manager.GameOver();
    }
    private void CapNhatThanhMau()
    {
        if (thanhMau != null)
        {
            thanhMau.fillAmount = mauHienTai / mauToiDa;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Win"))
        {
            Destroy(collision.gameObject);
            manager.GameWin();
        }
        if (collision.CompareTag("Heart"))
        {
            mauHienTai += 10f;
            Destroy (collision.gameObject);
        }
    }
}
