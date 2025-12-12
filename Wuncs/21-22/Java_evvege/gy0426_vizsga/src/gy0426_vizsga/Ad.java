/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0426_vizsga;

import java.util.Date;

/**
 *
 * @author Wuncs.David
 */
public class Ad {
    int id,rooms;
    String latlong;
    int floors;
    int area;
    String description;
    boolean freeofcharge;
    String imageURL;
    Date creatAt;
    Seller seller;
    Category category;

    public Ad(int id, int rooms, String latlong, int floors, int area, String description, String freeofcharge, String imageURL, Date creatAt,int sid, String sn,String sp,int cid, String cn) {
        this.id = id;
        this.rooms = rooms;
        this.latlong = latlong;
        this.floors = floors;
        this.area = area;
        this.description = description;
        this.freeofcharge = freeofcharge.equals("1");
        this.imageURL = imageURL;
        this.creatAt = creatAt;
        this.seller = new Seller(sid,sn,sp);
        this.category = new Category(cid, cn);
    }

    @Override
    public String toString() {
        return "ID: " + id + ", Rooms: " + rooms + ", Latlong: " + latlong + ", Floors: " + floors + ", Area: " + area + ", Description: " + description + ", FreeOfCharge: " + freeofcharge + ", ImageURL:" + imageURL + ", CreatAt=" + creatAt + ", " + seller + ", " + category;
    }
    
    
}
