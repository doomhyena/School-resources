extends Control

@onready var id: Label = $Id
@onready var username: Label = $Username
@onready var credit: Label = $Credit
@onready var http: HTTPRequest = $HTTPRequest
@onready var cookie: Button = $Cookie

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	id.text = "ID: "+Globals.id
	username.text = "Username: "+Globals.username
	credit.text = "Credit: "+str(Globals.credit)
	cookie.text = "+"+str(Globals.plus_cookies)+" süti"

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	id.text = "ID: "+str(Globals.id)
	username.text = "Username: "+str(Globals.username)
	credit.text = "Credit: "+str(Globals.credit)
	cookie.text = "+"+str(Globals.plus_cookies)+" süti"


func _on_logout_btn_pressed() -> void:
	Globals.id = "0"
	Globals.username = ""
	Globals.credit = "0"
	get_tree().change_scene_to_file("res://login.tscn")
	
	
func _on_cookie_pressed() -> void:
	
	http.request("http://192.168.3.88/14b/godot/getcookie.php?id="+Globals.id+"&plus="+str(Globals.plus_cookies))
	Globals.credit = int(Globals.credit)+Globals.plus_cookies
	credit.text = "Credit: "+str(Globals.credit)
	

func _on_perks_pressed() -> void:
	get_tree().change_scene_to_file("res://perks.tscn")
