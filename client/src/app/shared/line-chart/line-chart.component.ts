import { Component, Input, OnInit } from '@angular/core';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartData } from 'chart.js';

@Component({
  selector: 'app-line-chart',
  standalone: true,
  imports: [BaseChartDirective],
  templateUrl: './line-chart.component.html',
  host: { style: 'display: contents' }
})
export class LineChartComponent implements OnInit {
  @Input() title: string = '';
  @Input() labels: string[] = [];
  @Input() dataset1: number[] = [];
  @Input() dataset1Label: string = '';
  @Input() dataset2: number[] = [];
  @Input() dataset2Label: string = '';

  chartData!: ChartData<'line'>;

  chartOptions: ChartConfiguration<'line'>['options'] = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: { legend: { display: true } }
  };

  ngOnInit(): void {
    this.chartData = {
      labels: this.labels,
      datasets: [
        {
          data: this.dataset1,
          label: this.dataset1Label,
          borderColor: '#2e7d32',
          backgroundColor: 'rgba(46,125,50,0.2)',
          fill: true,
          tension: 0.4
        },
        ...(this.dataset2.length ? [{
          data: this.dataset2,
          label: this.dataset2Label,
          borderColor: '#fdd835',
          backgroundColor: 'rgba(253,216,53,0.2)',
          fill: true,
          tension: 0.4
        }] : [])
      ]
    };
  }
}