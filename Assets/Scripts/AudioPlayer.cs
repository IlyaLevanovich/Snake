using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip _diamond, _gulp;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayDiamondClip()
    {
        _audioSource.clip = _diamond;
        _audioSource.Play();
    }
    public void PlayGloupClip()
    {
        _audioSource.clip = _gulp;
        _audioSource.Play();
    }
}
