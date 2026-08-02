import { Component, Inject } from '@angular/core';
import { PdfExportService } from '../../services/pdf-export.service';

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [],
  templateUrl: './reports.component.html',
  host: { style: 'display: contents' }
})
export class ReportsComponent {
  headers = ['ID', 'Name', 'Department', 'Salary'];
  rows = [
    [1, 'Ahmed Mostafa', 'Engineering', 15000],
    [2, 'Sara Ali', 'Marketing', 12000],
    [3, 'Omar Khaled', 'Sales', 13500],
  ];

  constructor(@Inject(PdfExportService) private pdfService: PdfExportService) {}

  exportReport(): void {
    this.pdfService.exportTableToPdf(
      'Employee Report',
      this.headers,
      this.rows,
      'employee-report.pdf'
    );
  }
}