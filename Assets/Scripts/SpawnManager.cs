using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject greatswordPrefab;
    public GameObject cameraPrefab;

    public Canvas canvas;
    public GameObject greatswordUIPrefab;
    public GameObject healthUIPrefab;

    public GameObject enemyPrefab;
    public GameObject player;
    public float theRange;

    public bool cooldown = true;

    private PlayerController playerController;

    public GameObject gameOverScreen;
    private bool once = true;

    public void YouLose()
    {
        GameObject gameOverScreenSpawned = Instantiate(gameOverScreen, canvas.transform);
        gameOverScreenSpawned.name = gameOverScreen.name;
        once = !once;
    }

    void Start()
    {
        GameObject playerSpawned = Instantiate(playerPrefab, new Vector2(0, 0), playerPrefab.transform.rotation);
        playerSpawned.name = playerPrefab.name;
        player = playerSpawned;

        GameObject healthUISpawned = Instantiate(healthUIPrefab, canvas.transform);
        healthUISpawned.name = healthUIPrefab.name;

        GameObject greatswordUISpawned = Instantiate(greatswordUIPrefab, canvas.transform);
        greatswordUISpawned.name = greatswordUIPrefab.name;

        GameObject greatswordSpawned = Instantiate(greatswordPrefab, new Vector2(0, 0), greatswordPrefab.transform.rotation);
        greatswordSpawned.name = greatswordPrefab.name;

        GameObject cameraSpawned = Instantiate(cameraPrefab, new Vector2(0, 0), cameraPrefab.transform.rotation);
        cameraSpawned.name = cameraPrefab.name;

        GreatSwordController GreatSwordController = greatswordSpawned.GetComponent<GreatSwordController>();
        GreatSwordController.player = player.GetComponent<Transform>();
        GreatSwordController.killedCanvas = greatswordUISpawned.GetComponent<TextMeshProUGUI>();

        CameraController cameraController = cameraSpawned.GetComponent<CameraController>();
        cameraController.player = player.GetComponent<Transform>();

        playerController = player.GetComponent<PlayerController>();
        playerController.healthCanvas = healthUISpawned.GetComponent <TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown && playerController.alive)
        {
            SpawnEm();
        }
        if (!playerController.alive && once)
        {
            YouLose();
        }
    }

    private void SpawnEm()
    {
        cooldown = false;
        if (Random.value > 0.5)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(player.transform.position.x + Random.Range(-theRange, theRange), player.transform.position.y + 13), enemyPrefab.transform.rotation);
            enemy.name = enemyPrefab.name;
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.player = player;
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(player.transform.position.x + Random.Range(-theRange, theRange), player.transform.position.y - 13), enemyPrefab.transform.rotation);
            enemy.name = enemyPrefab.name;
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.player = player;
        }
        
        StartCoroutine(SpawnEmCooldown());
    }

    IEnumerator SpawnEmCooldown()
    {
        yield return new WaitForSeconds(0.2f);

        cooldown = true;
    }
}
