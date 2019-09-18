export enum CalcOperation {
    Multiplication = 0
}

export class CalcData {
    public Operand1: number = 0;
    public Operand2: number = 0;
    public Operation: CalcOperation = CalcOperation.Multiplication;
    public SimulateHighLatency: boolean = true;
}
