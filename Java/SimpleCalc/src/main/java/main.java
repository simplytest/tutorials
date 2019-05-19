import calculator.Calculator;

public class main {

    public static void main(String[] args) {
        Calculator calc = new Calculator();

        try {
            int operand1 = 0;
            int operand2 = 0;

            if (args.length > 1) {
                operand1 = Integer.parseInt(args[0]);
                operand2 = Integer.parseInt(args[1]);
            }

            int res = calc.mulitply(operand1, operand2);
            System.out.println("" + operand1 + " x " + operand2 + " = " + res);
        }
        catch (Exception e){
            System.out.println("Error occured: " + e.getMessage());
        }

    }
}
