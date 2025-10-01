using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject gameWinUi;
    [SerializeField] private GameObject gamePause;
    private bool isGameOver = false;
    private bool isGameWin = false;
    private int diem;
    [SerializeField] private TextMeshProUGUI textDiem;
    [SerializeField] private float thoiGianToiDa = 60f;
    [SerializeField] private TextMeshProUGUI textTime;

    private float thoiGianHienTai;
    void Start()
    {
        gameOverUi.SetActive(false);
        gameWinUi.SetActive(false);
        gamePause.SetActive(false);
        CapNhatDiem();
        thoiGianHienTai = thoiGianToiDa;
    }
    void Update()
    {
        CapNhatThoiGian();
    }
    public void CapNhatThoiGian()
    {
        if (thoiGianHienTai > 0)
        {
            thoiGianHienTai -= Time.deltaTime;
            textTime.text = Mathf.Ceil(thoiGianHienTai).ToString();
        }
        else
        {
            textTime.text = "0";
            GameWin();
        }
    }
    public float ThoiGian()
    {
        return thoiGianHienTai;
    }
    public void CapNhatDiem()
    {
        textDiem.text = "Score: " + diem.ToString();
    }
    public void CongDiem(int them)
    {
        diem += them;
        CapNhatDiem();
    }
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUi.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void GamePause()
    {
        Time.timeScale = 0;
        gamePause.SetActive(true);
    }
    public void ContinueGame()
    {
        gamePause.SetActive(false);
        Time.timeScale = 1;
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}
