using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난시간

    void Start()
    {
        timeAfterSpawn = 0f; // 최근 생성 이후의 누적 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);  // 최소 최대 생성주기 사이에서 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform; // PlayerControlller 컴포넌트를 가지는 게임 오브젝트르 찾아 조준 대상으로 설정
    }

   
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;   // timeAfterSpawn 갱신

        if(timeAfterSpawn > spawnRate)  // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        {
            timeAfterSpawn = 0f;    // 누적된 시간을 리셋

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //bulletPrefab의 복제본을 생성
            bullet.transform.LookAt(target);    // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);   // 다음번 생성 간격을 랜덤 지정
        }
    }
}
