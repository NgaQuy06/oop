using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float tocDoKeThu = 1f;
    protected Player player;
    [SerializeField] protected float mauToiDa = 100f;
    protected float mauHienTai;
    [SerializeField] protected Image thanhMau;
    [SerializeField] protected float satThuong = 5f;
    [SerializeField] protected float doTreGaySatThuong = 0.15f;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        mauHienTai = mauToiDa;
    } 
    protected virtual void Update()
    {
        DiChuyenDenNguoiChoi();
        CapNhatThanhMau();
    }
    protected virtual void DiChuyenDenNguoiChoi()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, tocDoKeThu * Time.deltaTime);
        }
    }
    public virtual void MatMau(float satThuong)
    {
        mauHienTai -= satThuong;
        mauHienTai = Mathf.Max(mauHienTai, 0);
        CapNhatThanhMau();
        if (mauHienTai <= 0)
        {
            Chet();
        }
    }
    protected virtual void Chet()
    {
        FindAnyObjectByType<Manager>()?.CongDiem(10);
        Destroy(gameObject);
    }
    protected void CapNhatThanhMau()
    {
        if (thanhMau != null)
        {
            thanhMau.fillAmount = mauHienTai / mauToiDa;
        }
    }
}
