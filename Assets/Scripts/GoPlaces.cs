using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacesPoint;
    [SerializeField] private Transform[] _arrayPlaces;

    private int _placeNumber;

    void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _arrayPlaces.Length; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }
    
    public void Update()
    {
        Transform place = _arrayPlaces[_placeNumber];
        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)
            FocusNextplace();
    }

    public Vector3 FocusNextplace()
    {
        _placeNumber++;

        if (_placeNumber == _arrayPlaces.Length)
            _placeNumber = 0;

        Vector3 newPlacePosition = _arrayPlaces[_placeNumber].position;
        transform.forward = newPlacePosition - transform.position;

        return newPlacePosition;
    }
}