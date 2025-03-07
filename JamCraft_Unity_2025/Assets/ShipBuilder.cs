using UnityEngine;
using UnityEngine.UI;

public class ShipBuilder : MonoBehaviour
{
    public int[,] shipMatrix; // 20x20 grid

    public int[] matrix_size = {5, 20};

    public RectTransform grid; // Assign in Unity Inspector
    public GameObject cellPrefab; // Assign a UI Image prefab in Inspector

    void Start()
    {
        shipMatrix = new int[matrix_size[0], matrix_size[1]];
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Clear existing children (if needed)
        foreach (Transform child in grid)
        {
            Destroy(child.gameObject);
        }

        // Ensure GridLayoutGroup is attached
        GridLayoutGroup layout = grid.GetComponent<GridLayoutGroup>();
        if (layout == null)
        {
            layout = grid.gameObject.AddComponent<GridLayoutGroup>();
        }

        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        layout.constraintCount = matrix_size[0]; // Set columns count
        layout.cellSize = new Vector2(30, 30); // Adjust size
        layout.spacing = new Vector2(2, 2); // Adjust spacing

        // Loop through the matrix and create UI elements
        for (int j = 0; j < shipMatrix.GetLength(1); j++)
            
        {
            for (int i = 0; i < shipMatrix.GetLength(0); i++)

            {
                GameObject cell = Instantiate(cellPrefab, grid);
                cell.name = $"Cell_{i}_{j}";

                Cell cell_script = cell.GetComponent<Cell>();
                cell_script.i = i;
                cell_script.j = j;
                cell_script.sb = this;

                // Set color based on matrix value (example)
                Image img = cell.GetComponent<Image>();
                if (img != null)
                {
                    img.color = shipMatrix[i, j] == 1 ? Color.red : Color.white;
                }
            }
        }
    }
}
