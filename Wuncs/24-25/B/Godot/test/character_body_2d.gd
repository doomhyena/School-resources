extends CharacterBody2D


const speed = 75
var cd = "none"

func _physics_process(delta):
	player_movement(delta)

func _ready():
	$AnimatedSprite2D.play("f_idle")

func player_movement(delta):
	
	
	if Input.is_action_pressed("ui_down") and Input.is_action_pressed("ui_right"):
		play_anim(1)
		cd = "right"
		velocity.x = speed
		velocity.y = speed
	elif Input.is_action_pressed("ui_up") and Input.is_action_pressed("ui_right"):
		play_anim(1)
		cd = "right"
		velocity.x = speed
		velocity.y = -speed
	elif Input.is_action_pressed("ui_up"):
		play_anim(1)
		cd = "up"
		velocity.x = 0
		velocity.y = -speed
	elif Input.is_action_pressed("ui_down"):
		play_anim(1)
		cd = "down"
		velocity.x = 0
		velocity.y = speed
	elif Input.is_action_pressed("ui_right"):
		play_anim(1)
		cd = "right"
		velocity.x = speed
		velocity.y = 0
	elif Input.is_action_pressed("ui_left"):
		play_anim(1)
		cd = "left"
		velocity.x = -speed
		velocity.y = 0
	else:
		play_anim(0)
		velocity.x = 0
		velocity.y = 0
	move_and_slide()	

func play_anim(movement):
	var dir = cd
	var anim = $AnimatedSprite2D
	
	if dir == "right":
		anim.flip_h = false
		if movement == 1:
			anim.play("s_walk")
		elif movement == 0:
			anim.play("s_idle")
	if dir == "left":
		anim.flip_h = true
		if movement == 1:
			anim.play("s_walk")
		elif movement == 0:
			anim.play("s_idle")
			
	if dir == "up":
		anim.flip_h = true
		if movement == 1:
			anim.play("b_walk")
		elif movement == 0:
			anim.play("b_idle")
	if dir == "down":
		anim.flip_h = true
		if movement == 1:
			anim.play("f_walk")
		elif movement == 0:
			anim.play("f_idle")
