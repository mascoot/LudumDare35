using UnityEngine;
using System.Collections;

public class FormationScript : MonoBehaviour {

	public Vector2 singleUnitSize;
	public GameObject[] units;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateFormationRectangle();
	}

	void UpdateFormationRectangle()
	{
		units = GameObject.FindGameObjectsWithTag("PlayerUnit");
		int numberOfUnits = units.Length;

		if(numberOfUnits > 0)
		{
			int bufferForSpace = 2;
			int numberOfPoints = numberOfUnits + bufferForSpace;
			float width = transform.localScale.x + 1;
			float height = transform.localScale.y + 1;
			bool isWidthLonger = (width > height) ? true : false;
			float totalLength = width + height;

			int numberOfRows = ((height / singleUnitSize.y) < 1) ? 1 : Mathf.FloorToInt(height / singleUnitSize.y);
			int numberOfCols = ((width / singleUnitSize.x) < 1) ? 1 : Mathf.FloorToInt(width / singleUnitSize.x);
			numberOfRows = (numberOfUnits < numberOfCols) ? 1 : numberOfRows;
			numberOfCols = (numberOfUnits < numberOfCols) ? numberOfUnits : numberOfCols;
			//print("(numberOfUnits/numberOfRows): " + ((float)numberOfUnits / numberOfRows));
			//print("numberOfCols: " + numberOfCols);
			numberOfCols = (Mathf.CeilToInt((float)(numberOfUnits)/numberOfRows) > numberOfCols) ? Mathf.CeilToInt((float)(numberOfUnits)/numberOfRows) : numberOfCols;
			//print("numberOfRows: " + numberOfRows);
			//print("numberOfCols: " + numberOfCols);

			float distanceBetweenWidth = width / (numberOfCols + bufferForSpace);
			float distanceBetweenHeight = height / (numberOfRows + bufferForSpace);

			for (int i = 0; i < numberOfRows; ++i)
			{
				for (int j = 0; j < numberOfCols; ++j)
				{
					if(((i * numberOfCols) + j) < numberOfUnits)
					{
						units[(i * numberOfCols) + j].GetComponent<Unit1Script>().positionToGo =
							new Vector3((((j + 1) - (numberOfCols / 2)) * distanceBetweenWidth), (((i + 1) - (numberOfRows / 2)) * distanceBetweenHeight), 0);
					}
				}
			}
		}


		//int numberOfRows = (int)Mathf.Floor((height + singleUnitSize.y) / singleUnitSize.y);
		//int numberOfCols = (int)Mathf.Floor(numberOfUnits / numberOfRows);
		//int numberOfUnitsPerRow = (numberOfUnits < numberOfRows) ? numberOfUnits : numberOfRows;

		//print("height: " + height);
		//print("singleUnitSize: " + singleUnitSize);
		//print("numberOfUnitsPerRow: " + numberOfUnitsPerRow);
		////print("Cols: " + numberOfCols);

		//float distanceBetweenWidth = width / numberOfUnitsPerRow;
		//float distanceBetweenHeight = height / numberOfCols;

		//for(int i=0; i < numberOfUnitsPerRow; ++i)
		//{
		//	for(int j=0; j < numberOfCols; ++j)
		//	{
		//		//Vector3(((j + 1) * distanceBetweenWidth), ((i + 1) * distanceBetweenHeight), 0);
		//		units[(i * numberOfCols) + j].GetComponent<Unit1Script>().positionToGo = new Vector3(((j + 1) * distanceBetweenWidth), ((i + 1) * distanceBetweenHeight), 0);
		//		print(new Vector3(((j + 1) * distanceBetweenWidth), ((i + 1) * distanceBetweenHeight), 0));
		//	}
		//}
	}
}
