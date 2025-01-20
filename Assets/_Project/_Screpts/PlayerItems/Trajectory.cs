using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project._Screpts.Player
{
    [Serializable]
    public class Trajectory
    {
        [Header("Trajectory Settings")] [SerializeField]
        private GameObject trajectoryPrefab;

        [SerializeField] private int trajectoryResolution = 30;
        [SerializeField] private float trajectoryPointSpacing = 0.1f;
        [SerializeField] private float trajectorySize = 1f;

        private List<GameObject> _trajectoryPoints = new List<GameObject>();

        public List<Vector2> CreateTrajectory(Vector2 startPosition, float jumpPower, float gravity)
        {
            List<Vector2> trajectoryPositions = new List<Vector2>();

            for (int i = 0; i < trajectoryResolution; i++)
            {
                float time = i * trajectoryPointSpacing;
                Vector2 position = CalculateTrajectoryPoint(startPosition, jumpPower, gravity, time);
                trajectoryPositions.Add(position);

                if (_trajectoryPoints.Count <= i)
                {
                    GameObject point = Object.Instantiate(trajectoryPrefab, position, Quaternion.identity);
                    point.SetActive(true);
                    point.transform.localScale = new Vector3(trajectorySize, trajectorySize, 1);
                    _trajectoryPoints.Add(point);
                }
                else
                {
                    _trajectoryPoints[i].transform.position = position;
                }
            }

            return trajectoryPositions;
        }

        private Vector2 CalculateTrajectoryPoint(Vector2 startPosition, float jumpPower, float gravity, float time)
        {
            float x = jumpPower * time;
            float y = jumpPower * time * 0.7f + 0.5f * gravity * time * time;
            return startPosition + new Vector2(x, y);
        }

        public void ClearTrajectory()
        {
            foreach (GameObject point in _trajectoryPoints)
            {
                Object.Destroy(point);
            }

            _trajectoryPoints.Clear();
        }
    }
}