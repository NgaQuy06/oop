using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] danhSachKeThu;
    [SerializeField] private Transform[] viTriXuatHien;
    [SerializeField] private float thoiGianXuatHien = 2f;
    void Start()
    {
        StartCoroutine(NgauNhienXuatHien());
    }
    private IEnumerator NgauNhienXuatHien()
    {
        while (true)
        {
            yield return new WaitForSeconds(thoiGianXuatHien);
            GameObject enemy = danhSachKeThu[Random.Range(0, danhSachKeThu.Length)];
            Transform viTri = viTriXuatHien[Random.Range(0, viTriXuatHien.Length)];
            Instantiate(enemy, viTri.position, Quaternion.identity);
        }
    }
}
