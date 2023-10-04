using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Animator animator;
    public string currentSkinId;
    public float force;
    public Rigidbody2D _birdRigid;
    public GameObject restartButton;

    void Start()
    {
        currentSkinId = SaveManager.Instance.GetData().skin;
        animator.SetBool(currentSkinId, true);

        _birdRigid = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _birdRigid.velocity = Vector2.up * force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            SaveManager.Instance.SetScore(GetComponent<Score>().score);
            Destroy(gameObject); Time.timeScale = 0;
            restartButton.SetActive(true);
        }
    }
}
