using System.Collections;
using UnityEngine;
using TMPro;

public abstract class Gun : MonoBehaviour
{
    protected float xoay = 180f;
    [SerializeField] protected Transform viTriDan;
    [SerializeField] protected GameObject dan;
    [SerializeField] protected float doTreBan = 0.15f;
    protected float lanBanTiepTheo;
    [SerializeField] protected int toiDaDan = 36;
    [SerializeField] protected int soLuongDanHienTai;
    [SerializeField] protected float doTreNapDan = 2f;
    [SerializeField] protected TextMeshProUGUI hienThiSoLuongDan;
    protected bool dangNapDan = false;
    protected void Start()
    {
        soLuongDanHienTai = toiDaDan;
        CapNhatHienThiSoLuongDan();
    }
    protected void Update()
    {
        XoaySung();
        Ban();
        NapDan();
    }
    protected void XoaySung()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 disp = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(disp.y, disp.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + xoay);
        if (angle < -90 || angle > 90) transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(1, -1, 1);
    }
    protected void Ban()
    {
        if (Input.GetMouseButton(0) && soLuongDanHienTai > 0 && Time.time > lanBanTiepTheo && dangNapDan == false)
        {
            lanBanTiepTheo = Time.time + doTreBan;
            Instantiate(dan, viTriDan.position, viTriDan.rotation);
            soLuongDanHienTai--;
            CapNhatHienThiSoLuongDan();
        }
    }
    protected void NapDan()
    {
        if (Input.GetMouseButtonDown(1) && soLuongDanHienTai < toiDaDan)
        {
            StartCoroutine(DoTreNapDan());
        }
        CapNhatHienThiSoLuongDan();
    }

    protected IEnumerator DoTreNapDan()
    {
        dangNapDan = true;
        hienThiSoLuongDan.text = "Nạp...";
        yield return new WaitForSeconds(doTreNapDan);
        soLuongDanHienTai = toiDaDan;
        dangNapDan = false;
    }
    protected void CapNhatHienThiSoLuongDan()
    {
        if (hienThiSoLuongDan != null && dangNapDan == false)
        {
            if (soLuongDanHienTai > 0)
            {
                hienThiSoLuongDan.text = soLuongDanHienTai.ToString();
            }
            else hienThiSoLuongDan.text = "Hết đạn";
        }
    }
}
