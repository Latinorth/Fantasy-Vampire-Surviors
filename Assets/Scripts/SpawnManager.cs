using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    private GameObject player;
    public float theRange;
    public bool cooldown = true;

    public TextMeshProUGUI YouLoseText;

    public void YouLose()
    {
        YouLoseText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        if (cooldown)
        {
            SpawnEm();
        }
        if (playerController.health == 0)
        {

        }
    }

    private void SpawnEm()
    {
        cooldown = false;
        player = GameObject.Find("Player");
        if (Random.value > 0.5)
        {
            Instantiate(enemyPrefab, new Vector2(player.transform.position.x + Random.Range(-theRange, theRange), player.transform.position.y + 13), enemyPrefab.transform.rotation);
        }
        else
        {
            Instantiate(enemyPrefab, new Vector2(player.transform.position.x + Random.Range(-theRange, theRange), player.transform.position.y - 13), enemyPrefab.transform.rotation);
        }
        StartCoroutine(SpawnEmCooldown());
    }

    IEnumerator SpawnEmCooldown()
    {
        yield return new WaitForSeconds(0.2f);

        cooldown = true;
    }
}
