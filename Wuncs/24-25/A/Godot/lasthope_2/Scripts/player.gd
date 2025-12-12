extends CharacterBody2D


const speed = 75
var cd = "n"

func _ready():
	$AnimatedSprite2D.play("idle_f")


func _physics_process(delta):
	player_movement(delta)

func player_movement(delta):
	
	if Input.is_action_pressed("ui_right"):
		p_anim(1)
		cd = "r"
		velocity.x = speed
		velocity.y = 0
	elif Input.is_action_pressed("ui_left"):
		p_anim(1)
		cd = "l"
		velocity.x = -speed
		velocity.y = 0
	elif Input.is_action_pressed("ui_up"):
		p_anim(1)
		cd = "u"
		velocity.x = 0
		velocity.y = -speed
	elif Input.is_action_pressed("ui_down"):
		p_anim(1)
		cd = "d"
		velocity.x = 0
		velocity.y = speed
	else:
		p_anim(0)
		velocity.x = 0
		velocity.y = 0
	
	move_and_slide()
	
func p_anim(movement):
	var anim = $AnimatedSprite2D
	var dir = cd
	
	if dir == "r":
		anim.flip_h = false
		if movement == 1:
			anim.play("move_s")
		elif movement == 0:
			anim.play("idle_s")
			
	if dir == "l":
		anim.flip_h = true
		if movement == 1:
			anim.play("move_s")
		elif movement == 0:
			anim.play("idle_s")
			
	if dir == "u":
		if movement == 1:
			anim.play("move_b")
		elif movement == 0:
			anim.play("idle_b")
			
	if dir == "d":
		if movement == 1:
			anim.play("move_f")
		elif movement == 0:
			anim.play("idle_f")
		
