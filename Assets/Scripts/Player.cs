using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5;
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start()
    {
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;

        _plantCountUI.UpdateSeeds(_numSeedsPlanted, _numSeedsLeft);
    }

    private void Update()
    {
        // movement
        Vector3 horizontalDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 verticalDirection = new Vector3(0, Input.GetAxis("Vertical"), 0);

        transform.Translate(horizontalDirection * _speed * Time.deltaTime);
        transform.Translate(verticalDirection * _speed * Time.deltaTime);


        // triggering planting seeds
        if (Input.GetKeyDown(KeyCode.Space) && _numSeedsLeft > 0)
            PlantSeed();

        _plantCountUI.UpdateSeeds(_numSeedsPlanted, _numSeedsLeft);
    }

    public void PlantSeed()
    {   
        Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity);
        _numSeedsLeft--;
        _numSeedsPlanted++;        
    }
}