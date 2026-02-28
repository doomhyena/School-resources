### Tervezett felosztás (5 subnet + host igények)

A 3 épület:

1. **A épület – Diák PC-k / tantermek** -> **79 host**
2. **B épület – Iroda / admin** -> **55 host**
3. **C épület – Tanári / labor** -> **25 host**
4. **Wi-Fi hálózat (diák/guest)** -> pl. 25–55 host
5. **Transit / gerinchálózat a 3 router között** -> kevés host, de kell OSPF-hez

### Trükk, hogy tényleg 5 subnet legyen

Ne 3 külön point-to-point link legyen a routerek között (az rögtön +3 subnet), hanem:

* a 3 router **ugyanarra a core/transit switchre** csatlakozik,
* és **1 közös transit alhálózaton** látják egymást OSPF-fel.

Így: 3 LAN + Wi-Fi + Transit = **pont 5 alhálózat**
### IP-címzés példa (VLSM, vizsgabarát logika)

Pl. alap tartomány: **10.10.0.0/16**

Host igények:

* 79 host → **/25** (126 host)
* 55 host → **/26** (62 host)
* 25 host → **/27** (30 host)
* Wi-Fi (pl. 25 host) → **/27**
* Transit (3 router) → **/29** (6 host)

Egy lehetséges kiosztás:

* Diák LAN: **10.10.0.0/25** (GW: 10.10.0.1)
* Admin LAN: **10.10.0.128/26** (GW: 10.10.0.129)
* Tanári/Labor: **10.10.0.192/27** (GW: 10.10.0.193)
* Wi-Fi: **10.10.0.224/27** (GW: 10.10.0.225)
* Transit: **10.10.1.0/29** (R1 .1, R2 .2, R3 .3)

(Nem muszáj pont ez, a **logika** a lényeg.)

### OSPF terv (egyszerű, prezentálható)

* Process ID: **1**
* Area: **0**
* Minden router hirdeti:

  * a saját LAN subnetjét
  * a transit subnetet

### Mit érdemes leadni március 14-re 

* Téma: **3 épületes iskola hálózata**
* Topológia vázlat (routerek–switchek–PC-k + Wi-Fi)
* **5 alhálózat VLSM táblázat** (név, host igény, hálózat, maszk, GW)
* Rövid leírás: melyik subnet mire való
* OSPF terv: process 1 / area 0 / hirdetett hálózatok