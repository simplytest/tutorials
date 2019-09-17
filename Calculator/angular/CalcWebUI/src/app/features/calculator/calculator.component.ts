import { Component, OnInit } from '@angular/core';
import { CalculatorService } from './calculator.service';
import { CalcData } from './calcdata';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {

  public result: number;

  public calcData: CalcData;

  constructor(private calcService:CalculatorService) { 
    this.calcData = new  CalcData();

  }

  ngOnInit() {
  }



  public async calculate(){
    console.log("Calc " + this.calcData.Operand1 + " " + this.calcData.Operand2);

    this.result = await this.calcService.multiply(this.calcData).toPromise();
  }

}
