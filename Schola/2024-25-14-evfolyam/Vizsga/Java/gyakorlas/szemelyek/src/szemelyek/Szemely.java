
package szemelyek;

/**
 *
 * @author Wuncs Dávid
 */
public class Szemely {
    private String nev;
    private int kor;
    private int nem;

    public Szemely(String nev, int kor, int nem) {
        this.nev = nev;
        this.kor = kor;
        this.nem = nem;
    }

    public int getNem() {
        return nem;
    }

    public void setNem(int nem) {
        this.nem = nem;
    }

    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public int getKor() {
        return kor;
    }

    public void setKor(int kor) {
        this.kor = kor;
    }

    @Override
    public String toString() {
        return nev;
    }
    
    
    
}
