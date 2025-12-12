extends CharacterBody2D

var speed = 100
var p_chase = false
var player = null

func _physics_process(delta: float):
	if p_chase:
		position += (player.position - position)/speed
		move_and_slide()

func _on_detection_body_entered(body: Node2D):
	player = body
	p_chase = true


func _on_detection_body_exited(body: Node2D) -> void:
	player = null
	p_chase = false
