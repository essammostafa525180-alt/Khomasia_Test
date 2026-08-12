import { Injectable } from '@angular/core';
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

@Injectable({
  providedIn: 'root'
})
export class PdfExportService {

  exportTableToPdf(
    title: string,
    headers: string[],
    rows: (string | number)[][],
    fileName: string = 'report.pdf'
  ): void {
    const doc = new jsPDF();

    doc.setFontSize(16);
    doc.text(title, 14, 15);

    autoTable(doc, {
      head: [headers],
      body: rows,
      startY: 22,
      theme: 'striped',
      headStyles: { fillColor: [52, 58, 64] } // لون قريب من AdminLTE dark
    });

    doc.save(fileName);
  }
}