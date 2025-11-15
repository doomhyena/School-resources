public class Kifejezes {
    private int elsoOperandus;
    private String operator;
    private int masodikOperandus;

    public Kifejezes(int elsoOperandus, String operator, int masodikOperandus) {
        this.elsoOperandus = elsoOperandus;
        this.operator = operator;
        this.masodikOperandus = masodikOperandus;
    }

    public int getElsoOperandus() {
        return elsoOperandus;
    }
    public String getOperator() {
        return operator;
    }
    public int getMasodikOperandus() {
        return masodikOperandus;
    }
}