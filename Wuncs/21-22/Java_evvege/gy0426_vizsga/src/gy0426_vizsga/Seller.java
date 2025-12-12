/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gy0426_vizsga;

/**
 *
 * @author Wuncs.David
 */
public class Seller {
    int id;
    String name,phone;

    public Seller(int id, String name, String phone) {
        this.id = id;
        this.name = name;
        this.phone = phone;
    }

    @Override
    public String toString() {
        return "Seller ID: " + id + ", Seller name: " + name + ", Seller phone" + phone;
    }
    
    
}
