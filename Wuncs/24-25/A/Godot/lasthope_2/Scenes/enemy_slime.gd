extends CharacterBody2D

var speed = 60
var chase = false
var player = null

func _physics_process(delta: float) -> void:
	if chase:
		position += (player.position - position)/speed
		
		$AnimatedSprite2D.play("move")
		
		move_and_slide()
	else:
		$AnimatedSprite2D.play("idle")


func _on_detection_body_entered(body: Node2D) -> void:
	player = body
	chase = true



func _on_detection_body_exited(body: Node2D) -> void:
	player = null
	chase = false
