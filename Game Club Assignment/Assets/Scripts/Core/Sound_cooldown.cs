using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip arrows;

    [SerializeField] private float attackCooldown;

    private void Start()
    {
        StartCoroutine(PlaySoundRepeatedly());
    }

    private System.Collections.IEnumerator PlaySoundRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackCooldown);
            SoundManager.instance.PlaySound(arrows);
        }
    }
}