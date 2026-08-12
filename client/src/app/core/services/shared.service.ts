import { Injectable } from '@angular/core';
import { exportTypeConst } from '../../Shared/constants/ExportType.const';
import { ExportColumn } from '../../Shared/Model/ExportColumn';
import html2canvas from 'html2canvas';
import { jsPDF } from 'jspdf';
@Injectable({
  providedIn: 'root'
})
export class SharedService {

export(data: any[], columns: ExportColumn[], type: string): void {
    const handlers: Record<string, () => void> = {
      [exportTypeConst.PDF]:   () => this.toPdf(data, columns),
      [exportTypeConst.CSV]:   () => this.toCsv(data, columns),
      [exportTypeConst.PRINT]: () => this.toPrint(data, columns),
      [exportTypeConst.COPY]:  () => this.toCopy(data, columns),
    };

    handlers[type]?.();
  }




  // ─── CSV ────────────────────────────────────────────────────

  private toCsv(data: any[], columns: ExportColumn[]): void {
    const header = columns.map(c => this.escapeCsv(c.label)).join(',');
    const rows = data.map(row =>
      columns.map(c => this.escapeCsv(row[c.key])).join(',')
    );

    const csv = '\uFEFF' + [header, ...rows].join('\r\n');
    this.downloadFile(csv, 'data.csv', 'text/csv;charset=utf-8;');
  }

  private escapeCsv(value: any): string {
    const str = value ?? '';
    if (str.toString().includes(',') || str.toString().includes('"') || str.toString().includes('\n')) {
      return `"${str.toString().replace(/"/g, '""')}"`;
    }
    return str;
  }


  private toPdf(data: any[], columns: ExportColumn[]): void {
    const tableHtml = this.buildTableHtml(data, columns);

    const container = document.createElement('div');
    container.style.cssText = 'position:fixed;left:-9999px;top:0;background:#fff;padding:20px;font-family:Arial,sans-serif;';
    container.innerHTML = `
      <style>
        table { width: 800px; border-collapse: collapse; }
        th, td { border: 1px solid #ddd; padding: 8px 12px; text-align: left; font-size: 13px; }
        th { background: #6b3fd4; color: #fff; font-weight: 600; }
        tr:nth-child(even) { background: #f9f9f9; }
      </style>
      ${tableHtml}`;
    document.body.appendChild(container);

    html2canvas(container, { scale: 2, useCORS: true }).then((canvas) => {
      document.body.removeChild(container);

      const imgData = canvas.toDataURL('image/png');
      const pdf = new jsPDF('l', 'mm', 'a4');
      const pdfWidth = pdf.internal.pageSize.getWidth();
      const pdfHeight = (canvas.height * pdfWidth) / canvas.width;

      pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
      pdf.save('data.pdf');
    });
 }


  private toPrint(data: any[], columns: ExportColumn[]): void {
    const tableHtml = this.buildTableHtml(data, columns);

    const html = `
      <!DOCTYPE html>
      <html>
      <head>
        <title>Print</title>
        <style>
          body { font-family: Arial, sans-serif; padding: 20px; }
          table { width: 100%; border-collapse: collapse; }
          th, td { border: 1px solid #ddd; padding: 8px 12px; text-align: left; font-size: 13px; }
          th { background: #333; color: #fff; font-weight: 600; }
          tr:nth-child(even) { background: #f5f5f5; }
          @media print { body { padding: 0; } }
        </style>
      </head>
      <body>
        ${tableHtml}
      </body>
      </html>`;

    const w = window.open('', '_blank');
    if (w) {
      w.document.write(html);
      w.document.close();
      w.print();
    }
  }


  private async toCopy(data: any[], columns: ExportColumn[]): Promise<void> {
    const header = columns.map(c => c.label).join('\t');
    const rows = data.map(row =>
      columns.map(c => row[c.key] ?? '').join('\t')
    );

    const text = [header, ...rows].join('\n');

    try {
      await navigator.clipboard.writeText(text);
    } catch {
      this.fallbackCopy(text);
    }
  }

  private fallbackCopy(text: string): void {
    const textarea = document.createElement('textarea');
    textarea.value = text;
    textarea.style.position = 'fixed';
    textarea.style.opacity = '0';
    document.body.appendChild(textarea);
    textarea.select();
    document.execCommand('copy');
    document.body.removeChild(textarea);
  }


  private buildTableHtml(data: any[], columns: ExportColumn[]): string {
    const thead = columns.map(c => `<th>${c.label}</th>`).join('');
    const rows = data.map(row => {
      const cells = columns.map(c => `<td>${row[c.key] ?? ''}</td>`).join('');
      return `<tr>${cells}</tr>`;
    }).join('');

    return `<table><thead><tr>${thead}</tr></thead><tbody>${rows}</tbody></table>`;
  }


  private downloadFile(content: string, fileName: string, mimeType: string): void {
    const blob = new Blob([content], { type: mimeType });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    a.click();
    URL.revokeObjectURL(url);
  }

}

