import { Component, Input, OnInit } from '@angular/core';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartData } from 'chart.js';

@Component({
  selector: 'app-donut-chart',
  standalone: true,
  imports: [BaseChartDirective],
  templateUrl: './donut-chart.component.html',
  host: { style: 'display: contents' }
})
export class DonutChartComponent implements OnInit {
  @Input() title: string = '';
  @Input() labels: string[] = [];
  @Input() values: number[] = [];

  chartData!: ChartData<'doughnut'>;

  chartOptions: ChartConfiguration<'doughnut'>['options'] = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: { legend: { position: 'bottom' } }
  };

  ngOnInit(): void {
    this.chartData = {
      labels: this.labels,
      datasets: [{
        data: this.values,
        backgroundColor: ['#2e7d32', '#fdd835', '#f57c00', '#558b2f', '#8d6e63']
      }]
    };
  }
}