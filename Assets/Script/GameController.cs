using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public GameObject Reticle;
    public GameObject winnerLabelObject;
    public GameObject RetryButton;

    private int remainingEnemies;

    private void OnEnable()
    {
        DestroyObject.EnemyDestroyed += HandleEnemyDestroyed;
    }

    private void OnDisable()
    {
        DestroyObject.EnemyDestroyed -= HandleEnemyDestroyed;
    }

    private void Start()
    {
        remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        UpdateScoreLabel();

        if (remainingEnemies == 0)
        {
            HandleAllEnemiesDefeated();
        }
        else
        {
            if (winnerLabelObject != null)
            {
                winnerLabelObject.SetActive(false);
            }

            if (Reticle != null)
            {
                Reticle.SetActive(true);
            }
        }
    }

    private void HandleEnemyDestroyed(DestroyObject enemy)
    {
        if (remainingEnemies > 0)
        {
            remainingEnemies--;
            UpdateScoreLabel();

            if (remainingEnemies == 0)
            {
                HandleAllEnemiesDefeated();
            }
        }
    }

    private void UpdateScoreLabel()
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = remainingEnemies.ToString();
        }
    }

    private void HandleAllEnemiesDefeated()
    {
        if (winnerLabelObject != null)
        {
            winnerLabelObject.SetActive(true);
        }

        if (Reticle != null)
        {
            Reticle.SetActive(false);
        }
    }

    public void OnRetry ()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }
}
