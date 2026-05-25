extends Control

@onready var http: HTTPRequest = $HTTPRequest
@onready var plus_2: Button = $Plus2
@onready var plus_5: Button = $Plus5
@onready var plus_10: Button = $Plus10
@onready var plus_25: Button = $Plus25
@onready var plus_50: Button = $Plus50

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	if Globals.plus_cookies >= 2:
		plus_2.hide()
	if Globals.plus_cookies >= 5:
		plus_5.hide()
	if Globals.plus_cookies >= 10:
		plus_10.hide()
	if Globals.plus_cookies >= 25:
		plus_25.hide()
	if Globals.plus_cookies >= 50:
		plus_50.hide()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_back_btn_pressed() -> void:
	get_tree().change_scene_to_file("res://main.tscn")


func _on_plus_2_pressed() -> void:
	buyPerk(500, 2)
	plus_2.hide()
	

func buyPerk(price, perk):
	
	if int(Globals.credit) >= price:
		http.request("http://192.168.3.88/14b/godot/buy.php?price="+str(price)+"&perk="+str(perk)+"&id="+str(Globals.id))
		Globals.plus_cookies = perk
		Globals.credit = str(int(Globals.credit)-price)
	


func _on_plus_5_pressed() -> void:
	buyPerk(1000, 5)
	plus_5.hide()


func _on_plus_10_pressed() -> void:
	buyPerk(2500, 10)
	plus_10.hide()


func _on_plus_25_pressed() -> void:
	buyPerk(5000, 25)
	plus_25.hide()


func _on_plus_50_pressed() -> void:
	buyPerk(10000, 50)
	plus_50.hide()
