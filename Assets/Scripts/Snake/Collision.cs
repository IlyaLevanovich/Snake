using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Collision : MonoBehaviour
{
    [SerializeField] private Transform[] _bodyParts;
    [SerializeField] private Text _scoreText;
    [SerializeField] private AudioPlayer _audioPlayer;

    private Color _color;
    private Fever _fever;
    private int _score = 0;

    private void Start()
    {
        _color = GetComponent<Color>();
        _fever = GetComponent<Fever>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var colorTrigger = other.GetComponent<ColorTrigger>();

        if (_fever.IsFever)
        {
            CreateTriggersSubject(colorTrigger);
            StartCoroutine(EatEnemy(other.gameObject));
            return;
        }
        CreateTriggersSubject(colorTrigger); 

        var enemyColor = other.GetComponent<EnemyColor>();
        if (enemyColor != null)
        {
            if (enemyColor.MeshColor == _color.CurrentColor)
                StartCoroutine(EatEnemy(other.gameObject));
            else
                SceneManager.LoadScene("Game");
        }
        CheckBomb(other.gameObject);
    }
    private void CreateTriggersSubject(ColorTrigger colorTrigger)
    {
        if(colorTrigger != null)
        {
            _color.ChangeColor(colorTrigger.CurrentColor);
            colorTrigger.CreateNextTrigger();
            colorTrigger.CreateNextGroup();
	       Destroy(colorTrigger.gameObject);	
        }
    }
    private void CheckBomb(GameObject subject)
    {
        if (subject.name == "Bomb")
            SceneManager.LoadScene("Game");
    }
    private IEnumerator EatEnemy(GameObject enemy)
    {
        Destroy(enemy);
        _audioPlayer.PlayGloupClip();
        foreach (var part in _bodyParts)
        {
            part.localScale *= 1.3f;
            yield return new WaitForSeconds(0.2f);
            part.localScale /= 1.3f;
        }
        _score ++;
        _scoreText.text = _score.ToString();
    }
    
}
