using UnityEngine;
using System.Collections;

public class FormationScript : MonoBehaviour {

	public Vector2 singleUnitSize;
	public float movementSpeed;
	public GameObject[] units;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMovement();
		UpdateFormationRectangle();
		
	}

	void UpdateMovement()
	{
		float xForce = Input.GetAxisRaw("Horizontal");
		float yForce = Input.GetAxisRaw("Vertical");
		Vector2 finalMovement = new Vector2(xForce, yForce);
		finalMovement.Normalize();
		finalMovement *= movementSpeed;

		transform.position += new Vector3( finalMovement.x, finalMovement.y, 0.0f);
		//rb.AddForce(totalForce * speed);
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
			float totalLength = width + height;

			int numberOfRows = ((height / singleUnitSize.y) < singleUnitSize.y) ? 1 : Mathf.FloorToInt(height / singleUnitSize.y);
			int numberOfCols = ((width / singleUnitSize.x) < singleUnitSize.x) ? 1 : Mathf.FloorToInt(width / singleUnitSize.x);
			print("numberOfRows1: " + numberOfRows);
			numberOfRows = (numberOfCols < numberOfUnits) ? numberOfRows : 1;
			numberOfCols = (numberOfUnits < numberOfCols) ? numberOfUnits : numberOfCols;
			print("numberOfRows2: " + numberOfRows);
			//print("numberOfCols: " + numberOfCols);
			numberOfCols = (Mathf.CeilToInt((float)(numberOfUnits)/numberOfRows) > numberOfCols) ? Mathf.CeilToInt((float)(numberOfUnits)/numberOfRows) : numberOfCols;
			//print("numberOfRows3: " + numberOfRows);
			//print("numberOfCols: " + numberOfCols);

			float distanceBetweenWidth = width / (numberOfCols + bufferForSpace);
			float distanceBetweenHeight = height / (numberOfRows + bufferForSpace);

			Vector2 forwardVec = new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
			//print("forwardVec: " + transform.rotation.z);
			forwardVec *= distanceBetweenHeight;
			Vector2 rightVec = new Vector2(Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad));
			rightVec *= distanceBetweenWidth;

			for (int i = 0; i < numberOfRows; ++i)
			{
				for (int j = 0; j < numberOfCols; ++j)
				{
					if(((i * numberOfCols) + j) < numberOfUnits)
					{
						Vector2 finalPos2D = (((j + 1) - (numberOfCols / 2)) * forwardVec) + (((i + 1) - (numberOfRows / 2)) * rightVec);
						units[(i * numberOfCols) + j].GetComponent<Unit1Script>().positionToGo = transform.position +
							new Vector3(finalPos2D.x, finalPos2D.y, 0);
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
