import { Component, OnInit } from '@angular/core';
import { CalculatorService } from './calculator.service';
import { CalcData } from './calcdata';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {

  public result: number;
  public calcData: CalcData;
  public calcInProgress: boolean = false;

  constructor(private calcService:CalculatorService, private toastr: ToastrService) { 
    this.calcData = new  CalcData();

  }

  ngOnInit() {
  }



  public async calculate(){
    try {
      this.calcInProgress = true;
      this.result = await this.calcService.calculate(this.calcData).toPromise();
      this.calcInProgress = false;
    }
    catch (e) {
      this.calcInProgress = false;
      this.toastr.error(e, 'Calculation failed');
    }  
  }

}
