using UnityEngine;
using System.Collections;

public class FormationScript : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;
	public float currentXScale;
	public float currentYScale;
	private float maximumXScale;
	private float minimumXScale;
	private float maximumYScale;
	private float minimumYScale;
	private Rigidbody2D rb;
	private Vector2 singleUnitSize;
	public GameObject[] units;

  public float bulletSpeed = 500.0f;
  public float firingDelay = 2.0f;
  private float firingInterval = 0.0f;

  // Use this for initialization
  void Start () {
		rb = GetComponent<Rigidbody2D>();
		singleUnitSize = new Vector2(1, 1);
		maximumXScale = 1;
		minimumXScale = 1;
		maximumYScale = 1;
		minimumYScale = 1;
		currentXScale = minimumXScale;
		currentYScale = minimumYScale;

    firingInterval = firingDelay;
}
	
	// Update is called once per frame
	void Update () {
    firingInterval -= Time.deltaTime;

    UpdateMovement();
		UpdateFormationRectangle();

    if (firingInterval < 0.0f)
      firingInterval = firingDelay;
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
			//transform.position += (forwardVec * movementSpeed * Time.deltaTime);
			Vector2 totalForce = new Vector2(forwardVec.x, forwardVec.y);
			rb.AddForce(totalForce * movementSpeed);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Vector3 forwardVec = transform.rotation * Vector3.right;
			//transform.position += (-forwardVec * movementSpeed * Time.deltaTime);
			Vector2 totalForce = new Vector2(-forwardVec.x, -forwardVec.y);
			rb.AddForce(totalForce * movementSpeed);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (currentYScale < maximumYScale) currentYScale += 1.0f;
			//if (transform.localScale.y < maximumYScale) transform.localScale += Vector3.up;
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (currentYScale > minimumYScale) currentYScale -= 1.0f;
			//if (transform.localScale.y > minimumYScale) transform.localScale += -Vector3.up;
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (currentXScale < maximumXScale) currentXScale += 1.0f;
			//if (transform.localScale.x < maximumXScale) transform.localScale += Vector3.right;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (currentXScale > minimumXScale) currentXScale -= 1.0f;
			//if (transform.localScale.x > minimumXScale) transform.localScale += -Vector3.right;
		}
	}

	void UpdateFormationRectangle()
	{
		units = GameObject.FindGameObjectsWithTag("PlayerUnit");
		int numberOfUnits = units.Length;
		maximumXScale = maximumYScale = Mathf.Ceil(Mathf.Sqrt(numberOfUnits));

		if(numberOfUnits > 0)
		{
			int bufferForSpace = 1;
			float width = currentXScale;
			float height = currentYScale;
			//float width = transform.localScale.x;
			//float height = transform.localScale.y;

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
					if(((i * numberOfCols) + j) < numberOfUnits)
					{
						Vector2 finalPos2D = new Vector2();
						finalPos2D += j * rightVec * distanceBetweenWidth;
						finalPos2D += i * forwardVec * distanceBetweenHeight;

						if (numberOfCols > 1) finalPos2D -= (((float)numberOfCols - 1.0f) / 2.0f) * distanceBetweenWidth * rightVec;
						if (numberOfRows > 1) finalPos2D -= (((float)numberOfRows - 1.0f) / 2.0f) * distanceBetweenHeight * forwardVec;

						units[(i * numberOfCols) + j].GetComponent<Unit1Script>().positionToGo = transform.position + new Vector3(finalPos2D.x, finalPos2D.y, 0);
            if (firingInterval < 0.0f)
              units[(i * numberOfCols) + j].GetComponent<Unit1Script>().FireForEffect(bulletSpeed);

          }
				}
			}
		}
	}
}
