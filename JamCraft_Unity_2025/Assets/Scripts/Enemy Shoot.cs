using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Vector2 shootInterval;
    public Vector2Int numOfBulletsInterval;
    public float spread;
    public float attackSpeed;
    float attackTime;

    float timeToNextRound;
    float bulletsLeft;

    GameObject player;
    public GameObject bullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {



        if (Mathf.Abs(transform.position.x)<10 && Mathf.Abs(transform.position.y) < 6)
        ShootWave();
    }

    void ShootWave () {
        timeToNextRound -= Time.deltaTime;
        if (timeToNextRound < 0) {
            bulletsLeft = Random.Range(numOfBulletsInterval.x, numOfBulletsInterval.y);
            timeToNextRound = Random.Range(shootInterval.x, shootInterval.y);
            attackTime = 0;
        }
        if (bulletsLeft > 0) {
            attackTime += Time.deltaTime;
            if (attackTime > attackSpeed) {
                attackTime -= attackSpeed;
                bulletsLeft -= 1;
                Shoot();
            }
        }

    }

    void Shoot () {
        print("skyd");
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector2 dirVector = (transform.position + Random.insideUnitSphere).normalized;
        if(player != null) dirVector = (player.transform.position - transform.position).normalized + Random.insideUnitSphere*spread;
        bul.transform.Rotate(0, 0, Mathf.Atan2(dirVector.y, dirVector.x) * 180 / Mathf.PI - 90);

    }
}
