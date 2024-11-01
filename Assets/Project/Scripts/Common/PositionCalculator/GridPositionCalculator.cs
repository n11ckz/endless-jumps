using UnityEngine;

namespace Project
{
    public class GridPositionCalculator : IPositionCalculator
    {
        private const GridLayout.CellSwizzle CellSwizzle = GridLayout.CellSwizzle.XZY;
        
        private readonly Grid _grid;
        private readonly Vector3 _cellCenterOffset;

        public GridPositionCalculator(Grid grid)
        {
            _grid = grid;
            _grid.cellSwizzle = CellSwizzle;

            _cellCenterOffset = new Vector3(_grid.cellSize.x / 2, 0, _grid.cellSize.y / 2);
        }

        public Vector3 GetNextPosition(Vector3 currentPosition, Vector3 direction)
        {
            Vector3Int invertedDirection = new Vector3Int(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.z));
            Vector3Int cellPosition = _grid.WorldToCell(currentPosition) + invertedDirection;

            float yHeight = currentPosition.y + _grid.cellSize.z;

            return _grid.CellToWorld(cellPosition).With(y: yHeight) + _cellCenterOffset;
        }
    }
}
