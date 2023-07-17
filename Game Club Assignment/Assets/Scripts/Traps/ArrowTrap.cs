using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;

    [Header("SFX")]
    [SerializeField] private AudioClip arrowSound;

    private void Attack()
    {
        cooldownTimer = 0;

        if (IsInCameraFrustum())
        {
            SoundManager.instance.PlaySound(arrowSound);
        }

        StartCoroutine(ActivateNextProjectile());
    }

    private IEnumerator ActivateNextProjectile()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay here as needed

        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private bool IsInCameraFrustum()
    {
        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        // Calculate the bounds of the arrow trap
        Bounds trapBounds = new Bounds(transform.position, Vector3.zero);
        foreach (var arrow in arrows)
        {
            trapBounds.Encapsulate(arrow.transform.position);
        }

        // Check if the arrow trap bounds intersect with any of the camera frustum planes
        if (GeometryUtility.TestPlanesAABB(frustumPlanes, trapBounds))
        {
            return true;
        }

        return false;
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
            Attack();
    }
}