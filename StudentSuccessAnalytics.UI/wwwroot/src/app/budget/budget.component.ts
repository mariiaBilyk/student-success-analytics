import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.css']
})
export class BudgetComponent implements OnInit {
  randData;
  col_ChartDatas = [
  [
        ['', 'Кількість'],
        ['Повторне вивчення', 30],
        ['Стипендія', 150],
        ['Підвищена стипендія', 16],
  ],
  [
        ['', 'Кількість'],
        ['Повторне вивчення', 30],
        ['Стипендія', 10],
        ['Підвищена стипендія', 18],
  ],
  [
        ['', 'Кількість'],
        ['Повторне вивчення', 30],
        ['Стипендія', 16],
        ['Підвищена стипендія', 177],
  ],
  [
        ['', 'Кількість'],
        ['Повторне вивчення', 30],
        ['Стипендія', 60],
        ['Підвищена стипендія', 9],
  ]];
  constructor() { }
  randomize(){
  	let i = Math.floor((Math.random() * 3));
  	this.randData= this.col_ChartDatas[i];
  }
  ngOnInit() {
  }

}
