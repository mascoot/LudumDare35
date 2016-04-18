using UnityEngine;
using System.Collections;

public class FormationScript : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;
	public float scalingSpeed;
	public float maximumXScale;
	public float minimumXScale;
	public float maximumYScale;
	public float minimumYScale;
	public Vector2 singleUnitSize;
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
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.W))
		{
			Vector3 forwardVec = transform.rotation * Vector3.right;
			transform.position += (forwardVec * movementSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Vector3 forwardVec = transform.rotation * Vector3.right;
			transform.position += (-forwardVec * movementSpeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			if(transform.localScale.y < maximumYScale) transform.localScale += (Vector3.up * scalingSpeed * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			if (transform.localScale.y > minimumYScale) transform.localScale += (-Vector3.up * scalingSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (transform.localScale.x < maximumXScale) transform.localScale += (Vector3.right * scalingSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (transform.localScale.x > minimumXScale) transform.localScale += (-Vector3.right * scalingSpeed * Time.deltaTime);
		}
	}

	void UpdateFormationRectangle()
	{
		units = GameObject.FindGameObjectsWithTag("PlayerUnit");
		int numberOfUnits = units.Length;

		if(numberOfUnits > 0)
		{
			int bufferForSpace = 1;
			int numberOfPoints = numberOfUnits + bufferForSpace;
			float width = transform.localScale.x;
			float height = transform.localScale.y;
			float totalLength = width + height;

			int numberOfRows = ((height / singleUnitSize.y) < singleUnitSize.y) ? 1 : Mathf.FloorToInt(height / singleUnitSize.y);
			int numberOfCols = ((width / singleUnitSize.x) < singleUnitSize.x) ? 1 : Mathf.FloorToInt(width / singleUnitSize.x);
			numberOfRows = (numberOfCols < numberOfUnits) ? numberOfRows : 1;
			numberOfCols = (numberOfUnits < numberOfCols) ? numberOfUnits : numberOfCols;
			numberOfCols = (Mathf.CeilToInt((float)(numberOfUnits)/numberOfRows) > numberOfCols) ? Mathf.CeilToInt((float)(numberOfUnits)/numberOfRows) : numberOfCols;
			float distanceBetweenWidth = width / (numberOfCols + bufferForSpace);
			float distanceBetweenHeight = height / (numberOfRows + bufferForSpace);

			Vector2 forwardVec = new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
			Vector2 rightVec = new Vector2(Mathf.Cos((transform.rotation.eulerAngles.z - 90) * Mathf.Deg2Rad), Mathf.Sin((transform.rotation.eulerAngles.z - 90) * Mathf.Deg2Rad));

			for (int i = 0; i < numberOfRows; ++i)
			{
				for (int j = 0; j < numberOfCols; ++j)
				{
					if((i * numberOfCols) + j < units.Length)
					{
						Vector2 finalPos2D = new Vector2();
						finalPos2D += j * rightVec * distanceBetweenWidth;
						finalPos2D += i * forwardVec * distanceBetweenHeight;

						if (numberOfCols > 1) finalPos2D -= (((float)numberOfCols - 1.0f) / 2.0f) * distanceBetweenWidth * rightVec;
						if (numberOfRows > 1) finalPos2D -= (((float)numberOfRows - 1.0f) / 2.0f) * distanceBetweenHeight * forwardVec;

						units[(i * numberOfCols) + j].GetComponent<Unit1Script>().positionToGo = transform.position + new Vector3(finalPos2D.x, finalPos2D.y, 0);
						//units[(i * numberOfCols) + j].GetComponent<Animator>().Play("walk");
					}
				}
			}
		}
	}
}
