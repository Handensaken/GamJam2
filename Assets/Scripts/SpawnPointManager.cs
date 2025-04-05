using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player1;
    public GameObject player2;

    [Header("SpawnPoints")]
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    [Header("Win Round")]
    public TextMeshProUGUI winText;
    public float respawnDeley;
    public TextMeshProUGUI _countdownText;
    [Header("Win Game")]
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private TextMeshProUGUI _winGameText;
    [SerializeField] private float _respawnDelayedMovement = 1f;


    [Header("Points Gui")]
    public TextMeshProUGUI player1PointsText;
    public TextMeshProUGUI player2PointsText;
    private float _Player1Points = 0;
    private float _Player2Points = 0;

    void Start()
    {
        GameEventsManager.instance.OnPlayerDeath += OnPlayerDeath;
        SetPointsText();
        Respawn();

    }
    void OnDisable()
    {
        GameEventsManager.instance.OnPlayerDeath -= OnPlayerDeath;
    }
    void OnPlayerDeath(GameObject player)
    {
        if (player2 != player)
        {
            _Player2Points++;
            winText.text = player2.name + " won this game";
        }
        else
        {
            _Player1Points++;
            winText.text = player1.name + " won this game";
        }
        SetPointsText();
        if (_Player1Points == 3 || _Player2Points == 3)
        {
            WinGame();
        }
        else
        {
            Invoke(nameof(Respawn), respawnDeley);
        }
    }
    void Respawn()
    {
        StartCoroutine(Countdown(3));
        GameEventsManager.instance.WeRespawnPlayer();

        winText.text = "";
        player1.gameObject.SetActive(true);
        player1.GetComponent<PlayerMovement>().DisableMovment(_respawnDelayedMovement);
        player2.gameObject.SetActive(true);
        player2.GetComponent<PlayerMovement>().DisableMovment(_respawnDelayedMovement);

        SetPosition();
    }
    private void WinGame()
    {
        if (_winMenu != null)
        {
            _winMenu.SetActive(true);
        }
        if (_Player1Points == 3)
        {
            if (_winGameText != null)
            {
                _winGameText.text = player1.name + " Won This Round!";
            }
        }
        else if (_Player2Points == 3)
        {
            if (_winGameText != null)
            {
                _winGameText.text = player2.name + " Won This Round!";
            }
        }
    }
    void SetPointsText()
    {
        if (player1PointsText != null)
        {
            player1PointsText.text = _Player1Points.ToString();
        }
        if (player2PointsText != null)
        {
            player2PointsText.text = _Player2Points.ToString();
        }
    }
    void SetPosition()
    {
        player1.transform.position = spawnPoint1.position;
        player2.transform.position = spawnPoint2.position;
    }
    void DoStuff(int nr)
    {
        if (_countdownText != null)
        {
            _countdownText.text = nr.ToString();
        }
    }
    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            DoStuff(counter);
            yield return new WaitForSeconds(1);
            counter--;
        }
        _countdownText.text = "";
    }
}
