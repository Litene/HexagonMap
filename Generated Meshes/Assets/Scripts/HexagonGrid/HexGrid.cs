using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonGrid {
    public class HexGrid : MonoBehaviour {
        [SerializeField] private int _width = 6;
        [SerializeField] private int _height = 6;
        [SerializeField] private HexCell _cell;
        private HexCell[] _cells;

        private void Awake() {
            _cells = new HexCell[_width * _height]; // why not two dimensional?

            for (int z = 0, i = 0; z < _height; z++) {
                // declare iterator variable in outer ring when working with 1D array, and increment inside inner ring, to get index correct.
                for (int x = 0; x < _width; x++) {
                    CreateCell(x, z, i++); 
                }
            }
        }

        private void CreateCell(int x, int z, int i) {
            Vector3 pos;
            pos.x = x * 10f; // offset
            pos.y = 0;
            pos.z = z * 10; // offset

            HexCell cell = _cells[i] = Instantiate<HexCell>(_cell); 
            Transform cellTransform; 
            (cellTransform = cell.transform).transform.SetParent(transform, false); // never seen this declaration before.
            cellTransform.localPosition = pos; // localpos vs pos, TODO: read.
        }
    }
}