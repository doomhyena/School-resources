/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0426b_vizsga;

import java.util.Date;

/**
 *
 * @author Wuncs.David
 */
public class Ad {
    private int id;
    private int rooms;
    private String latlong;
    private int floors;
    private int area;
    private String description;
    private boolean freeofcharge;
    private String imageURL;
    private Date createAt;
    private Seller seller;
    private Category category;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getRooms() {
        return rooms;
    }

    public void setRooms(int rooms) {
        this.rooms = rooms;
    }

    public String getLatlong() {
        return latlong;
    }

    public void setLatlong(String latlong) {
        this.latlong = latlong;
    }

    public int getFloors() {
        return floors;
    }

    public void setFloors(int floors) {
        this.floors = floors;
    }

    public int getArea() {
        return area;
    }

    public void setArea(int area) {
        this.area = area;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public boolean isFreeofchange() {
        return freeofcharge;
    }

    public void setFreeofcharge(boolean freeofchange) {
        this.freeofcharge = freeofchange;
    }

    public String getImageURL() {
        return imageURL;
    }

    public void setImageURL(String imageURL) {
        this.imageURL = imageURL;
    }

    public Date getCreateAt() {
        return createAt;
    }

    public void setCreateAt(Date createAt) {
        this.createAt = createAt;
    }

    public Seller getSeller() {
        return seller;
    }

    public void setSeller(Seller seller) {
        this.seller = seller;
    }

    public Category getCategory() {
        return category;
    }

    public void setCategory(Category category) {
        this.category = category;
    }

    public Ad(int id, int rooms, String latlong,
            int floors, int area, String description,
            String freeofcharge, String imageURL,
            Date createAt,int sid, String sn, String sp,
            int cid, String cn) {
        this.id = id;
        this.rooms = rooms;
        this.latlong = latlong;
        this.floors = floors;
        this.area = area;
        this.description = description;
        this.freeofcharge = freeofcharge.equals("1");
        this.imageURL = imageURL;
        this.createAt = createAt;
        this.seller = new Seller(sid, sn, sp);
        this.category = new Category(cid, cn);
    }

    @Override
    public String toString() {
        return "ID: " + id + ", Rooms: " + rooms + ", Latlong: " + latlong + ", Floors: " + floors + ", Area: " + area + ", Description: " + description + ", Freeofcharge: " + freeofcharge + ", imageURL: " + imageURL + ", CreateAt: " + createAt + ", " + seller + ", " + category;
    }
    
    
    
    
}
