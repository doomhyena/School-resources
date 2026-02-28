## Diák LAN (79 host)

- Hálózat: **10.10.0.0/25**
- Maszk: **255.255.255.128**
- GW (Diák router LAN interfész): **10.10.0.1**
- Host tartomány: 10.10.0.2 – 10.10.0.126
- Broadcast: 10.10.0.127

## Admin LAN (55 host)

- Hálózat: **10.10.0.128/26**
- Maszk: **255.255.255.192**
- GW (Fő router LAN interfész az Admin felé): **10.10.0.129**
- Host tartomány: 10.10.0.130 – 10.10.0.190
- Broadcast: 10.10.0.191

## Tanári LAN (25 host)

- Hálózat: **10.10.0.192/27**
- Maszk: **255.255.255.224**
- GW (Tanári router LAN interfész): **10.10.0.193**
- Host tartomány: 10.10.0.194 – 10.10.0.222
- Broadcast: 10.10.0.223

## Wi-Fi LAN (25 host)

- Hálózat: **10.10.0.224/27**
- Maszk: **255.255.255.224**
- GW (Fő router WiFi interfész): **10.10.0.225**
- Host tartomány: 10.10.0.226 – 10.10.0.254
- Broadcast: 10.10.0.255

---

# 2) Transit hálózatok (router–router) — a te rajzodhoz igazítva

Mivel **2 darab router-router link van**, két subnet kell:

## Transit 1: Diák router ↔ Fő router

- **10.10.1.0/30**
- Maszk: **255.255.255.252**
- Diák router serial: **10.10.1.1**
- Fő router serial: **10.10.1.2**
- Broadcast: 10.10.1.3
## Transit 2: Tanári router ↔ Fő router

- **10.10.1.4/30**
- Maszk: **255.255.255.252**
- Tanári router serial: **10.10.1.5**
- Fő router serial: **10.10.1.6**
- Broadcast: 10.10.1.7

_(Ez így “kicsit több subnet”, de te mondtad, hogy nem gond 😄)_

---

# 3) Konkrét IP-k az eszközeidre (javaslat)

## Diák LAN (10.10.0.0/25)

- PC0: **10.10.0.10** /25, GW **10.10.0.1**
- PC1: **10.10.0.11** /25, GW **10.10.0.1**

## Admin LAN (10.10.0.128/26)

- PC3: **10.10.0.140** /26, GW **10.10.0.129**
- PC4: **10.10.0.141** /26, GW **10.10.0.129**
- Server0: **10.10.0.130** /26, GW **10.10.0.129**

## Tanári LAN (10.10.0.192/27)

- PC2: **10.10.0.200** /27, GW **10.10.0.193**
- Laptop0: **10.10.0.201** /27, GW **10.10.0.193**

## WiFi LAN (10.10.0.224/27)

- AP (menedzsment IP, ha kell): **10.10.0.226** /27, GW **10.10.0.225**
- Smartphone0: **10.10.0.230** /27, GW **10.10.0.225**
- Laptop1: **10.10.0.231** /27, GW **10.10.0.225**

---

# 4) Router interfészek – név szerint (amit te látsz)

## 2901 Diák LAN router

- LAN (a Diák Switch felé) pl. **Gi0/0**: `10.10.0.1/25`
- Serial a Fő router felé pl. **Se0/0/1**: `10.10.1.1/30`

## 2901 Fő router

- Admin LAN felé (Admin switch) pl. **Gi0/0**: `10.10.0.129/26`
- WiFi felé (AP felé) pl. **Gi0/1**: `10.10.0.225/27`
- Serial a Diák router felé pl. **Se0/0/1**: `10.10.1.2/30`
- Serial a Tanári router felé pl. **Se0/0/0**: `10.10.1.6/30`

## 2901 Tanári LAN router

- LAN (Tanári switch) pl. **Gi0/0**: `10.10.0.193/27`
    
- Serial a Fő router felé pl. **Se0/0/1**: `10.10.1.5/30`
    

> **Fontos:** nálad az interfész neve lehet kicsit más (Gi0/0 vs Gi0/1, Se0/0/0 vs Se0/0/1).  
> Mindegy, a lényeg: _melyik kábel melyik portban van_. Packet Tracer kiírja a kábel végén.
# 5) Mini tipp a Serial linkhez (ha piros marad)

A serial kapcsolatoknál az egyik oldalon “clock” ikon szokott lenni (DCE).  
Ott kell majd:

- `clock rate 64000`  
    és mindkét serial interfészen:
- `no shutdown`