using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Fever : MonoBehaviour
{
    [SerializeField] private Text _diamondText;
    [SerializeField] private GameObject _feverStatus;
    [SerializeField] private AudioPlayer _audioPlayer;

    private int _diamondAmount = 0;
    private int _diamondStrick = 0;
    public bool IsFever { get; private set; } = false;

    private float _timerStrick = 2f;
    private float _delay = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (IsFever) return;

        if (other.GetComponent<Diamond>())
        {
            _audioPlayer.PlayDiamondClip();
            _diamondAmount++;
            _diamondStrick++;
            _diamondText.text = _diamondAmount.ToString();

            Destroy(other.gameObject);

            if (_diamondStrick >= 3)
                StartCoroutine(FeverActivate());
        }   
    }

    private void Update()
    {
        if (_delay < 0)
        {
            _diamondStrick = 0;
            _delay = _timerStrick;
        }
        _delay -= 0.01f;
    }
    private IEnumerator FeverActivate()
    {
        SetFever(true);
        yield return new WaitForSeconds(5f);
        _diamondAmount = 0;
        _diamondText.text = _diamondAmount.ToString();
        SetFever(false);
    }
    private void SetFever(bool isActive)
    {
        IsFever = isActive;
        _feverStatus.SetActive(isActive);
    }

}
