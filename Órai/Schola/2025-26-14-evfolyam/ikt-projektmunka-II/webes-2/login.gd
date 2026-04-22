extends Control

@onready var username: LineEdit = $Username
@onready var password: LineEdit = $Password
@onready var http: HTTPRequest = $HTTPRequest
@onready var username_error: Panel = $UsernameError
@onready var password_error: Panel = $PasswordError

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func _on_login_btn_pressed() -> void:
	var log_usern = username.get_text()
	var log_pass = password.get_text()

	http.request_completed.connect(_on_request_completed)
	http.request("http://127.0.0.1/14b/godot/gamelogin.php?username="+log_usern+"&password="+log_pass)
	
func _on_request_completed(result, response_code, header, body):
	
	if response_code == 200:
		
		var text = body.get_string_from_utf8()
		var data = JSON.parse_string(text)
		
		if int(data.id) == 0:
			username.text = ""
			password.text = ""
			print("Hibás adatok!")
		elif int(data.id) == -1:
			username.text = ""
			password.text = ""
			username_error.show()
			password_error.hide()
		elif int(data.id) == -2:
			username.text = ""
			password.text = ""
			password_error.show()
			username_error.hide()
		else:
			Globals.id = data.id
			Globals.username = data.username
			Globals.credit = data.credit
			get_tree().change_scene_to_file("res://main.tscn")
