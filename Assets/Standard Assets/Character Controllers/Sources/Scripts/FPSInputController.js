private var motor : CharacterMotor;
private var playerAnim : Animator;
// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);

	playerAnim = GameObject.Find("Beetle").GetComponent(Animator);
}

// Update is called once per frame
function Update () {
	// Get the input vector from kayboard or analog stick
	var h = Input.GetAxis("Horizontal");
	var v = Input.GetAxis("Vertical");
	var directionVector = new Vector3(h, 0, v);
	var walking : boolean = h != 0f || v != 0f;
		Debug.Log("h is " + h);
		Debug.Log("v is " + v);
		
		Debug.Log("Walking is " + walking);
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	playerAnim.SetBool("IsWalking", walking);
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
