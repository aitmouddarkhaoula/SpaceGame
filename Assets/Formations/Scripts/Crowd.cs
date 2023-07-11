using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Crowd : MonoBehaviour {
    private FormationBase _formation;

    public FormationBase Formation {
        get {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private float _unitSpeed = 2;
    [SerializeField] private Transform _parent;

    [SerializeField] public List<GameObject> spawnedUnits = new List<GameObject>();
    private List<Vector3> _points = new List<Vector3>();
    public bool dead=false;

    private void Awake() {
        SetFormation();
    }

    private void Update() {

       
        if (spawnedUnits.Count==0)
        {
            dead = true;
            Destroy(gameObject);
            //EnemiesSpawn.Instance.NextCrowd();
        }
        //SpawnSystem.Instance.SpawnEnemies(transform.gameObject, transform, plane);
    }

    private void SetFormation() {
        _points = Formation.EvaluatePoints().ToList();

        if (_points.Count > spawnedUnits.Count) {
            var remainingPoints = _points.Skip(spawnedUnits.Count);
            Spawn(remainingPoints);
        }
        else if (_points.Count < spawnedUnits.Count) {
            Kill(spawnedUnits.Count - _points.Count);
        }
        for (var i = 0; i < spawnedUnits.Count; i++) {
            spawnedUnits[i].transform.position = Vector3.MoveTowards(spawnedUnits[i].transform.position, transform.position + _points[i], _unitSpeed * Time.deltaTime);
        }
    }

    private void Spawn(IEnumerable<Vector3> points) {
        foreach (var pos in points) {
            var unit = Instantiate(_unitPrefab, transform.position + pos, Quaternion.identity, _parent);
            spawnedUnits.Add(unit);
        }
    }

    private void Kill(int num) {
        for (var i = 0; i < num; i++) {
            var unit = spawnedUnits.Last();
            spawnedUnits.Remove(unit);
            Destroy(unit.gameObject);
        }
    }
    public void Reset()
    {
        Destroy(gameObject);
    }

}