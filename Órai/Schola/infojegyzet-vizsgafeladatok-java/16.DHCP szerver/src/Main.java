import java.io.*;
import java.util.*;

class MacIP {
    String MAC;
    String IP;

    public MacIP(String sor) {
        String[] s = sor.strip().split(";");
        this.MAC = s[0].trim();
        this.IP = s[1].trim();
    }
}

class Test {
    String tipus;
    String cim;

    public Test(String sor) {
        String[] s = sor.strip().split(";");
        this.tipus = s[0].trim();
        this.cim = s[1].trim();
    }
}

public class Main {
    static Map<String, String> dberelt = new HashMap<>();
    static Map<String, String> dreserv = new HashMap<>();
    static Set<String> lexcl = new HashSet<>();


    static void feladat(int n) {
        System.out.println(n + ". feladat:");
    }

    public static int Req(String maddr) {
        if (dberelt.containsKey(maddr)) {
            return 0;
        } else if (dreserv.containsKey(maddr)) {
            String kiIP = dreserv.get(maddr);
            if (dberelt.containsValue(kiIP)) {
                return -1;
            } else {
                dberelt.put(maddr, kiIP);
                return 1;
            }
        } else {
            int i = 100;
            while (i <= 199) {
                String kiIP = "192.168.10." + i;
                if (dberelt.containsValue(kiIP) ||
                        lexcl.contains(kiIP) ||
                        dreserv.containsValue(kiIP)) {
                    i++;
                } else {
                    break;
                }
            }
            if (i > 199) {
                return -2;
            }
            dberelt.put(maddr, "192.168.10." + i);
            return 1;
        }
    }

    public static int Rel(String ip) {
        Iterator<Map.Entry<String, String>> it = dberelt.entrySet().iterator();
        while (it.hasNext()) {
            Map.Entry<String, String> entry = it.next();
            if (entry.getValue().equals(ip)) {
                it.remove();
                return 1;
            }
        }
        return -1;
    }

    public static void main(String[] args) throws IOException {
        feladat(1);
        try (BufferedReader br = new BufferedReader(new FileReader("excluded.csv"))) {
            String line;
            while ((line = br.readLine()) != null) {
                lexcl.add(line.strip());
            }
        }

        try (BufferedReader br = new BufferedReader(new FileReader("reserved.csv"))) {
            String line;
            while ((line = br.readLine()) != null) {
                MacIP ob = new MacIP(line);
                dreserv.put(ob.MAC, ob.IP);
            }
        }

        try (BufferedReader br = new BufferedReader(new FileReader("dhcp.csv"))) {
            String line;
            while ((line = br.readLine()) != null) {
                MacIP ob = new MacIP(line);
                dberelt.put(ob.MAC, ob.IP);
            }
        }

        List<Test> ltest = new ArrayList<>();
        try (BufferedReader br = new BufferedReader(new FileReader("test.csv"))) {
            String line;
            while ((line = br.readLine()) != null) {
                ltest.add(new Test(line));
            }
        }

        feladat(2);
        for (Test k : ltest) {
            if (k.tipus.equalsIgnoreCase("request")) {
                Req(k.cim);
            } else {
                Rel(k.cim);
            }
        }

        feladat(3);
        try (BufferedWriter bw = new BufferedWriter(new FileWriter("dhcp_kesz.csv"))) {
            for (Map.Entry<String, String> e : dberelt.entrySet()) {
                bw.write(e.getKey() + ";" + e.getValue());
                bw.newLine();
            }
        }
    }
}
