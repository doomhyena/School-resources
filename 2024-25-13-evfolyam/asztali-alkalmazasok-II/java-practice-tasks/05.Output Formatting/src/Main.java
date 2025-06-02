import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("================================");

        for (int i = 0; i < 3; i++) {
            String text = scanner.next();
            int number = scanner.nextInt();
            System.out.printf("%-15s%03d%n", text, number);
        }

        System.out.println("================================");

        scanner.close();
    }
}
