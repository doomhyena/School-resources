extends CharacterBody2D


const speed = 85
var cd = "none"

var health = 100
var enemy_inrange = false
var enemy_coold = false
var p_isalive = true

var rnd = RandomNumberGenerator.new()

func _physics_process(delta):
	player_movement(delta)
	enemy_attack()
	if health <= 0:
		health = 0
		self.queue_free()
	
func _ready():
	$AnimatedSprite2D.play("idle_f")
	
func player_movement(delta):
	
	if Input.is_action_pressed("ui_right"):
		pa(1)
		cd = "right"
		velocity.x = speed
		velocity.y = 0
	elif Input.is_action_pressed("ui_left"):
		pa(1)
		cd = "left"
		velocity.x = -speed
		velocity.y = 0
	elif Input.is_action_pressed("ui_up"):
		pa(1)
		cd = "up"
		velocity.x = 0
		velocity.y = -speed
	elif Input.is_action_pressed("ui_down"):
		pa(1)
		cd = "down"
		velocity.x = 0
		velocity.y = speed
	else:
		pa(0)
		velocity.x = 0
		velocity.y = 0
	move_and_slide()
	
func pa(movement):
	var dir = cd
	var anim = $AnimatedSprite2D
	
	if dir == "right":
		anim.flip_h = false
		if movement == 1:
			anim.play("move_s")
		elif movement == 0:
			anim.play("idle_s")
	elif dir == "left":
		anim.flip_h = true
		if movement == 1:
			anim.play("move_s")
		elif movement == 0:
			anim.play("idle_s")
	elif dir == "up":
		anim.flip_h = true
		if movement == 1:
			anim.play("move_b")
		elif movement == 0:
			anim.play("idle_b")
	elif dir == "down":
		anim.flip_h = true
		if movement == 1:
			anim.play("move_f")
		elif movement == 0:
			anim.play("idle_f")
			


func _on_hitzone_body_entered(body: Node2D) -> void:
	if body.has_method("enemy"):
		enemy_inrange = true



func _on_hitzone_body_exited(body: Node2D) -> void:
	if body.has_method("enemy"):
		enemy_inrange = false

func enemy_attack():
	if enemy_inrange and !enemy_coold:
		health -= rnd.randi_range(10,15)
		enemy_coold = true
		$Cooldown.start()
		print("player: ",health)


func _on_cooldown_timeout() -> void:
	enemy_coold = false

func player():
	pass
