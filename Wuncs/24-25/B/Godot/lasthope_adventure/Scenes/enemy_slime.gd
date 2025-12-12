extends CharacterBody2D


var speed = 90
var player = null
var chase = false

var health = 50
var pl_inzone = false


func _physics_process(delta: float) -> void:
	hit()
	if chase:
		position += (player.position - position)/speed
		$AnimatedSprite2D.play("movement")
		
		if (player.position.x - position.x) < 0:
			$AnimatedSprite2D.flip_h = true
		else:
			$AnimatedSprite2D.flip_h = false
		
		move_and_slide()
	else:
		$AnimatedSprite2D.play("idle")

func _on_detection_body_entered(body: Node2D) -> void:
	player = body
	chase = true

func _on_detection_body_exited(body: Node2D) -> void:
	player = null
	chase = false

func enemy():
	pass



func _on_hitzone_body_entered(body: Node2D) -> void:
	if body.has_method("player"):
		pl_inzone = true


func _on_hitzone_body_exited(body: Node2D) -> void:
	if body.has_method("player"):
		pl_inzone = false

func hit():
	if pl_inzone:
		health -= 15
		print("sh:",health)
		if health <= 0:
			self.queue_free()
